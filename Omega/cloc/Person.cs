using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    public class Person
    {
        protected int id;
        protected string firstname;
        protected string lastname;
        protected string email;
        protected int tel;

        public int ID
        {
            get
            {
                return id;
            }
        }
        public string Firstname
        {
            get { return firstname; }
            set
            {
                if (value.Length >= 3 && Regex.IsMatch(value, @"^[a-zA-Z0-9@.]*$"))
                    firstname = value;
                else
                    MessageBox.Show("Neplatné jméno!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (value.Length >= 3 && Regex.IsMatch(value, @"^[a-zA-Z0-9@.]*$"))
                    lastname = value;
                else
                    MessageBox.Show("Neplatné příjmení!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int Tel
        {
            get { return tel; }
            set
            {
                if (value.ToString().Length == 9)
                    tel = value;
                else
                    MessageBox.Show("Neplatné telefoní číslo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value.Contains("@") && value.Length > 5)
                {
                    email = value;
                }
                else
                {
                    MessageBox.Show("Neplatný email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Updates person. Based on column parameter calls other methods that update the column in database.
        /// Also gets the type of object that called this method and other update methods are called with the specific table.
        /// </summary>
        /// <param name="Column">Column to update in datebase</param>
        public void Update(string Column)
        {
            string table = null;
            switch (this.GetType().ToString().Replace("Omega.", ""))
            {
                case "Visitor":
                    table = "Visitor";
                    break;
                case "User":
                    table = "employee";
                    break;
            }
            switch (Column)
            {               
                case "Firstname":
                    UpdateFirstname(table);
                    break;
                case "Lastname":
                    UpdateLastname(table);
                    break;
                case "Tel":
                    UpdateTel(table);
                    break;
                case "Email":
                    UpdateEmail(table);
                    break;
            }
        }

        /// <summary>
        /// updates firstname colomn in database.
        /// </summary>
        /// <param name="table">name of the table to update</param>
        public void UpdateFirstname(string table)
        {
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("update " + table + " set firts_name = @lastname where id = @id;", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", this.ID));
                command.Parameters.Add(new MySqlParameter("@lastname", this.Firstname));
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// updates lastname colomn in database.
        /// </summary>
        /// <param name="table">name of the table to update</param>
        public void UpdateLastname(string table)
        {
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("update " + table + " set last_name = @lastname where id = @id;", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", this.ID));
                command.Parameters.Add(new MySqlParameter("@lastname", this.Lastname));
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// updates tel colomn in database.
        /// </summary>
        /// <param name="table">name of the table to update</param>
        public void UpdateTel(string table)
        {
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("update " + table + " set tel = @tel where id = @id;", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", this.ID));
                command.Parameters.Add(new MySqlParameter("@tel", this.Tel));
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// updates email colomn in database.
        /// </summary>
        /// <param name="table">name of the table to update</param>
        public void UpdateEmail(string table)
        {
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("update " + table + " set email = @email where id = @id;", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", this.ID));
                command.Parameters.Add(new MySqlParameter("@email", this.Email));
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// delets from database visitor or employee the calls this method
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            try
            {
                string table = null;
                switch (this.GetType().ToString().Replace("Omega.", ""))
                {
                    case "Visitor":
                        table = "Visitor";
                        break;
                    case "User":
                        table = "employee";
                        break;
                }
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("delete from " + table + " where id = @id", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", this.ID));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while deleting " + this.GetType().ToString().Replace("Alpha3.", "") + "! It is probably referenced in another table! Cannot be deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
