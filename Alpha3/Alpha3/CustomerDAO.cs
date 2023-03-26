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
    class CustomerDAO
    {
        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        /// <summary>
        /// Metoda z tabulky uzivatel vytáhne vševhny řádky a předělá je na objekty, které se vlkádají do listu
        /// </summary>
        /// <returns>list se zákazníky</returns>
        public List<Customer> GetAllCustomers()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            List<Customer> Customers = new List<Customer>();
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from uzivatel", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer c = new Customer(Convert.ToInt32(reader[0]));
                        c.Firstname = reader[1].ToString();
                        c.Email = reader[3].ToString();
                        c.Lastname = reader[2].ToString();
                        Customers.Add(c);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting customers info!", "Error", button, icon);
            }
            return Customers;
        }
        /// <summary>
        /// Metada z databáze dostane jen jeden zápis a to zápis s ID ve stupním parametru
        /// </summary>
        /// <param name="id">ID zákazníka který se má vypsat</param>
        /// <returns>objekt type customer s odpovídajcím ID</returns>
        public Customer GetCustomerByID(int id)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            Customer c = null;
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from uzivatel where id = @id", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", id));
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        c = new Customer(Convert.ToInt32(reader[0]));
                        c.Firstname = reader[1].ToString();
                        c.Email = reader[3].ToString();
                        c.Lastname = reader[2].ToString();
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting customers info!", "Error", button, icon);
            }
            return c;
        }
    }
}
