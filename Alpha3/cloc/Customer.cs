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
    class Customer: Person
    {
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;
        public Customer(int id) : base(id)
        {
            this.id = id;
        }
        public Customer() : base() { }
        /// <summary>
        /// Zákazník který si tuto metodu zavolá se vloží do databáze
        /// </summary>
        public void Create()
        {
            try
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("insert into uzivatel(jmeno, prijmeni, email) values(@jmeno, @prijmeni, @email); ", conn))
                {
                    //vložení parametrů
                    command.Parameters.Add(new MySqlParameter("@jmeno", this.Firstname));
                    command.Parameters.Add(new MySqlParameter("@jmeno", this.Lastname));
                    command.Parameters.Add(new MySqlParameter("@jmeno", this.Email));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while creating " + this.GetType().ToString().Replace("Alpha3.", "") + "!", "Error", button, icon);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
