using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Alpha3
{
    class Person
    {
        protected int id;
        private string firstname;
        private string lastname;
        private string email;
        //private string tel;

        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        public int ID
        {
            get
            {
                return id;
            }
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                if (value.Length <= 1)
                {
                    MessageBox.Show("Jméno musí být delší!");
                }
                else
                {
                    firstname = value;
                }
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                if (value.Length <= 1)
                {
                    MessageBox.Show("Příjmení musí být delší!");
                }
                else
                {
                    lastname = value;
                }
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (!(value.Contains("@") && value.Length > 5))
                {
                    MessageBox.Show("Email musí obsahovat @ a musí být delší než 5 znaků!");
                }
                else
                {
                    email = value;
                }
            }
        }

        public Person(int id)
        {
            this.id = id;
        }
        public Person() { }
        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }
        /// <summary>
        /// Update Jmena u trid oddedenych od Person
        /// </summary>
        public void UpdateFname()
        {
            try
            {
                string table = null;
                switch (this.GetType().ToString().Replace("Alpha3.", ""))
                {
                    case "Customer":
                        table = "Uzivatel";
                        break;
                    case "Employee":
                        table = "Zamestnanci";
                        break;
                }
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("update " + table + " set jmeno = @jmeno where id = @id", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", this.ID));
                    command.Parameters.Add(new MySqlParameter("@jmeno", this.Firstname));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while updating " + this.GetType().ToString().Replace("Alpha3.", "") + "s!", "Error", button, icon);
            }
        }
        /// <summary>
        /// Update prijmeni u trid oddedenych od Person
        /// </summary>
        public void UpdateLname()
        {
            try
            {
                string table = null;
                switch (this.GetType().ToString().Replace("Alpha3.", ""))
                {
                    case "Customer":
                        table = "Uzivatel";
                        break;
                    case "Employee":
                        table = "Zamestnanci";
                        break;
                }
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("update " + table + " set prijmeni = @prijmeni where id = @id", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", this.ID));
                    command.Parameters.Add(new MySqlParameter("@prijmeni", this.Lastname));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while updating " + this.GetType().ToString().Replace("Alpha3.", "") + "s!", "Error", button, icon);
            }
        }
        /// <summary>
        /// Update Emailu u trid oddedenych od Person
        /// </summary>
        public void UpdateEmail()
        {
            try
            {
                string table = null;
                switch (this.GetType().ToString().Replace("Alpha3.", ""))
                {
                    case "Customer":
                        table = "Uzivatel";
                        break;
                    case "Employee":
                        table = "Zamestnanci";
                        break;
                }
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("update " + table + " set email = @email where id = @id", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", this.ID));
                    command.Parameters.Add(new MySqlParameter("@email", this.Email));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while updating " + this.GetType().ToString().Replace("Alpha3.", "") + "s!", "Error", button, icon);
            }
        }    
        /// <summary>
        /// Object Employee nebo customer ktery si tuto metodu se smaze z databaze
        /// </summary>
        /// <returns>Pokud metoda probehne bez chyb vrati se true</returns>
        public bool Delete()
        {
            try 
            {
                string table = null;
                switch (this.GetType().ToString().Replace("Alpha3.", ""))
                {
                    case "Customer":
                        table = "Uzivatel";
                        break;
                    case "Employee":
                        table = "Zamestnanci";
                        break;
                }
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("delete from " + table + " where id = @id", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", this.ID));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while deleting " + this.GetType().ToString().Replace("Alpha3.", "") + "! It is probably referenced in another table! Cannot be deleted!", "Error", button, icon);
                return false;
            }
            return true;
        }
    }
}
