using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Omega
{
    class DataBaseConnection
    {
		private static MySqlConnection conn = null;
		private DataBaseConnection()
		{
		}
		public static MySqlConnection GetConnection()
		{
			if (conn == null)
			{
				MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
				connectionString.Server = ReadSetting("server");
				connectionString.UserID = ReadSetting("User");
				connectionString.Password = ReadSetting("Password");
				connectionString.Database = ReadSetting("Database");
				conn = new MySqlConnection(connectionString.ConnectionString);
				try
				{
					conn.Open();
				}
				catch (SqlException)
				{
					MessageBox.Show("Error while connecting to a database.");
				}
			}
			return conn;
		}

		private static string ReadSetting(string key)
		{
			var appSettings = ConfigurationManager.AppSettings;
			string result = appSettings[key] ?? "Not Found";
			return result;
		}
	}
}
