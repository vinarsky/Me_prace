using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha3
{
    class EmployeeDAO
    {
        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        /// <summary>
        /// Metoda získá data o všech zaměstnanců
        /// </summary>
        /// <returns>list se všemi zaměstnanci</returns>
        public List<Employee> GetAllEmployees()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            List<Employee> Employees = new List<Employee>();
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from zamestnanci;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee e = new Employee(Convert.ToInt32(reader[0]));
                        e.Firstname = reader[1].ToString();
                        e.Email = reader[3].ToString();
                        e.Lastname = reader[2].ToString();
                        if (!(reader.IsDBNull(7)))
                            e.DateOfEmployment = DateTime.Parse(reader[7].ToString());
                        Employees.Add(e);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting employee info!", "Error", button, icon);
            }
            return Employees;
        }
    }
}
