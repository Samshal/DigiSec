using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assemblies;
using System.IO;
using System.Collections;

namespace Digital_Secretary
{
    class Reminder
    {
         public string name
        {
            get;
            set;
        }

        public string note
        {
            get;
            set;
        }
        public DateTime time
        {
            get;
            set;
        }

        public DateTime date
        {
            get;
            set;
        }

        public string directory
        {
            get;
            set;
        }

        public Reminder()
        {
            this.directory = @"C:\Digital Secretary\Digital Secretary\data\reminder\";
        }
        private void clean()
        {
            name = name.Replace(":".ToString(), "-".ToString());
            name = name.Replace("?".ToString(), "_".ToString());
            name = name.Replace("*".ToString(), ",".ToString());
        }
        public string unclean(string data)
        {
            data = data.Replace("-".ToString(), ":".ToString());
            data = data.Replace("_".ToString(), "?".ToString());
            data = data.Replace(",".ToString(), "*".ToString());
            return data;
        }
        private bool checkFormat(string data)
        {
            Stringify stringsplit = new Stringify();
            char[] delim = { Convert.ToChar(".") };
            string[] data_arr = stringsplit.getArray(data, delim);
            string extension = data_arr[1];
            if (extension.ToLower() == "reminder")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool save()
        {
            if (this.name == "" || this.note == "")
            {
                return false;
            }
            else
            {
                clean();
                try
                {
                    Assemblies.File file = new Assemblies.File();
                    int val = file.Create(1, directory + name);
                    val = file.Create(0, directory + name + "\\note.reminder");
                    val = file.Create(0, directory + name + "\\time.reminder");
                    val = file.Create(0, directory + name + "\\date.reminder");
                    file.WriteData(directory + name + "\\note.reminder", note);
                    file.WriteData(directory + name + "\\time.reminder", time.ToString());
                    file.WriteData(directory + name + "\\date.reminder", date.ToString());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public ArrayList reminders()
        {
            Assemblies.File file = new Assemblies.File();
            DirectoryInfo dirinfo = new DirectoryInfo(this.directory);
            DirectoryInfo[] files = dirinfo.GetDirectories();
            ArrayList reminders = new ArrayList();
            foreach (DirectoryInfo _file in files)
            {
                string name = _file.Name;
                ArrayList data = new ArrayList();
                name = unclean(name);
                data.Add(name);
                reminders.Add(data);
            }
            return reminders;
        }
    }
}
