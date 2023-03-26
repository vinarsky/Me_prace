using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    class Log
    {
        private string Action;
        private string User;
        private DateTime Time;

        public Log(string action, string user)
        {
            Action = action;
            User = user;
            Time = DateTime.Now;
            LogToFile();
        }

        public void LogToFile()
        {            
            var appSettings = ConfigurationManager.AppSettings;
            string path = appSettings["LogFile"];
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(this.ToString());
            }
        }

        public override string ToString()
        {
            return $"{Time} - {User} - {Action}";
        }
    }
}
