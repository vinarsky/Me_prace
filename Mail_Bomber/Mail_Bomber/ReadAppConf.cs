using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Mail_Bomber
{
    internal class ReadAppConf
    {
        /// <summary>
        /// Reads a data from file app.config, that is used to configure the application.
        /// </summary>
        /// <param name="key">Key to an value</param>
        /// <returns>Value that is hidde under a given key.</returns>
        public static string ReadSettings(string key)
        {
            try
            {
                string result = "";

                XDocument config = XDocument.Load(@"..\..\Configs\Settings.xml");
                result = GetValueFromXml(config, key);
                return result;
            }
            catch (Exception ex) 
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show($"Error loading settings: {ex.Message}", "ErrorSettings", button, icon);
                return null;
            }
        }

        public static string ReferencePlacement(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (Exception ex) 
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show($"Error loading settings: {ex.Message}", "ErrorSettings", button, icon);
                return null;
            }
        }


        /// <summary>
        /// Extracets data from settings.xml
        /// </summary>
        /// <param name="config"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetValueFromXml(XDocument config, string key)
        {
            return config.Descendants("add")
                         .FirstOrDefault(x => (string)x.Attribute("key") == key)
                         ?.Attribute("value")?.Value;
        }


        /// <summary>
        /// Reads the interval in which the mails will be send.
        /// </summary>
        /// <returns>string with minimum seconds and maximum seconds devided by -</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int ReadInterval()
        {
            Random rnd = new Random();
            int interval = 0;
            try
            {
                string result = ReadSettings("Interval");
                interval = rnd.Next(int.Parse(result.Split('-')[0]),int.Parse(result.Split('-')[1]));
                return int.Parse(interval + "000");
            }
            catch (Exception ex)
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show($"Error loading settings: {ex.Message}", "ErrorInterval", button, icon);
                return 0;
            }
        }


        /// <summary>
        /// Reads what kind of change user wants to test.
        /// </summary>
        /// <returns>List of folder's names with changes</returns>
        public static List<string> ReadWhatChangesToSend()
        {
            List<string> result = new List<string>();
            for (int i = ConfigurationManager.AppSettings.Count - 1; i >= 0; i = i - 1)
            {
                try
                {
                    var appSettings = ConfigurationManager.AppSettings;
                    if (appSettings[i] is "True" || appSettings[i] is "true")
                        result.Add(appSettings.GetKey(i));
                }
                catch (Exception ex) 
                {
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    MessageBox.Show($"Error loading settings: {ex.Message}", "ErrorChangesSelection", button, icon);
                }
            }
            return result;
        }
    }
}
