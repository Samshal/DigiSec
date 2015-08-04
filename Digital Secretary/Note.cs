using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assemblies;
using System.Collections;
using System.IO;

namespace Digital_Secretary
{
    class Note
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

        public string directory
        {
            get;
            set;
        }

        public Note()
        {
            this.directory = @"C:\Digital Secretary\Digital Secretary\data\";
        }
        private void clean()
        {
            name = name.Replace(":".ToString(), "-".ToString());
            name = name.Replace(" ".ToString(), "_".ToString());
            name = name.Replace(".".ToString(), ",".ToString());
        }
        public string unclean(string data)
        {
            data = data.Replace("-".ToString(), ":".ToString());
            data = data.Replace("_".ToString(), " ".ToString());
            data = data.Replace(",".ToString(), " ".ToString());
            return data;
        }
        private bool checkFormat(string data)
        {
            Stringify stringsplit = new Stringify();
            char[] delim = { Convert.ToChar(".") };
            string[] data_arr = stringsplit.getArray(data, delim);
            string extension = data_arr[1];
            if (extension.ToLower() == "quicknote")
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
                Assemblies.File file = new Assemblies.File();
                int val = file.Create(0,  directory + name + ".quicknote");
                file.WriteData(directory + name + ".quicknote", note);
                return true;
            }
        }

        public ArrayList notes()
        {
            Assemblies.File file = new Assemblies.File();
            DirectoryInfo dirinfo = new DirectoryInfo(this.directory);
            FileInfo[] files = dirinfo.GetFiles();
            ArrayList notes = new ArrayList();
            foreach(FileInfo _file in files)
            {
                string name = _file.Name;
                ArrayList data = new ArrayList();
                if (checkFormat(name))
                {
                    DateTime time = _file.CreationTime;
                    DateTime date = _file.LastAccessTime;
                    name = unclean(name);
                    data.Add(name);
                    data.Add(time);
                    data.Add(date);
                }
                notes.Add(data);
            }
            return notes;
        }

        public void notecontent()
        {
            clean();
            Assemblies.File file = new Assemblies.File();
            note = file.ReadData(directory + name + ".quicknote", 0);
        }
    }
}
