using System;
using Assemblies;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Auth
{
    public class Username
    {
        public string username
        {
            set;
            get;
        }
        public string password
        {
            set;
            get;
        }
    }

    public class LoginAuth
    {
        private string username;
        private string password;
        protected File file_manager;

        public string location
        {
            get;
            set;
        }
        public LoginAuth()
        {
            file_manager = new File();
            location = @"C:\Digital Secretary\Digital Secretary\data\bin\user.csv";
        }

        public string Username
        {
            set
            {
                username = value;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
        }

        public bool validate()
        {
            int totalUsers = file_manager.CountLines(location);
            string usersinfile = file_manager.ReadData(location, -1);
            Stringify stringify = new Stringify();
            char[] delim = { Convert.ToChar(";") };
            char[] miled = { Convert.ToChar(",") };
            List<Username> usernames = new List<Username>();
            string[] users = stringify.getArray(usersinfile, delim);
            foreach (string user in users)
            {

                try
                {
                    string _username = stringify.getArray(user, miled)[1];
                    string _password = stringify.getArray(user, miled)[2];
                    usernames.Add(new Username { username = _username, password = _password });
                }
                catch (IndexOutOfRangeException)
                {

                }
            }
            return isUserExists(usernames);
        }

        public bool isUserExists(List<Username> usernames)
        {
            IEnumerable<Username> Query = (from user in usernames where user.username == username && user.password == password select user);
            if (Query.ToArray().Length < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}