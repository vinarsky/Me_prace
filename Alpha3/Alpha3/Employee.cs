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
    class Employee: Person
    {

        private DateTime dateOfEmployment;

        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        public DateTime DateOfEmployment
        {
            get
            {
                return dateOfEmployment;
            }
            set
            {
                dateOfEmployment = value;
            }
        }
        public Employee(int id) : base(id)
        {
            this.id = id;
        }
        public Employee() : base() { }
        /// <summary>
        /// Employee který si tuto metodu zavolá se vloží do databáze
        /// </summary>
        /// <returns>Poklud vše proběhne OK vratí se true</returns>
        public bool Create()
        {
            try
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("insert into Employee(firts_name, last_name, role_id, password, username, email, tel, HireDate) values(@firts_name, @last_name, @role_id, @password, @username, @email, @tel, @HireDate); ", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@firts_name", this.Firstname));
                    command.Parameters.Add(new MySqlParameter("@last_name", this.Lastname));
                    command.Parameters.Add(new MySqlParameter("@role_id", this/));
                    command.Parameters.Add(new MySqlParameter("@password", this.Firstname));
                    command.Parameters.Add(new MySqlParameter("@username", this.Lastname));
                    command.Parameters.Add(new MySqlParameter("@email", this.Email));
                    command.Parameters.Add(new MySqlParameter("@tel", this.DateOfEmployment));
                    command.Parameters.Add(new MySqlParameter("@HireDate", this.Email));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while creating employee!", "Error", button, icon);
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
