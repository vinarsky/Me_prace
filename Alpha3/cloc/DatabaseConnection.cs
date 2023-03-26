using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha3
{
	class DatabaseConnection
	{
		private static MySqlConnection conn = null;
		private DatabaseConnection()
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

