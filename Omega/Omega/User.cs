using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    public enum Access
    {
        admin = 1,
        basic_access = 2,
        restricted_access = 3
    }
    public class User:Person
    {
        private string username;
        private string password;
        public Access access;
        private DateTime dateOfEmployment;
        
        public Access Access
        {
            get { return access; }
            set { access = value; }
        }
        public string Username
        {
            get { return username; }
            set 
            {
                if (value.Length > 3 && Regex.IsMatch(value, @"^[a-zA-Z0-9@.]*$"))
                    username = value;
                else
                    MessageBox.Show("Neplatné uživatelské jméno!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Password
        {
            get { return password; }
            set 
            {
                if (value.Length < 4 || Regex.IsMatch(value, @"^[^'].*'.*$"))
                    MessageBox.Show("špatné heslo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    password = value;
            }
        }

        public DateTime DateOfEmployment
        {
            get
            {
                return dateOfEmployment;
            }
            set
            {
                if (value <= DateTime.Now)
                    dateOfEmployment = value;
                else
                    MessageBox.Show("Neplatné údaje!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public User(int id) : base(id)
        {
            this.id = id;
        }

        public User() : base() { }

        public string EncodePassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA512 sha512 = SHA512.Create();
            byte[] hashBytes = sha512.ComputeHash(passwordBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public void UpdateUsername()
        {
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("update employee set Username = @username where id = @id;", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", this.ID));
                command.Parameters.Add(new MySqlParameter("@username", this.Username));
                command.ExecuteNonQuery();
            }
        }
        public void UpdatePassword()
        {
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("update employee set password = @password where id = @id;", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", this.ID));
                command.Parameters.Add(new MySqlParameter("@password", this.password));
                command.ExecuteNonQuery();
            }
        }

        public bool Insert(int role_id)
        {
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("insert into Employee(firts_name, last_name, role_id, password, username, email, tel, HireDate) values(@firts_name, @last_name, @role_id, @password, @username, @email, @tel, @HireDate); ", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@firts_name", this.Firstname));
                    command.Parameters.Add(new MySqlParameter("@last_name", this.Lastname));
                    command.Parameters.Add(new MySqlParameter("@role_id", role_id));
                    command.Parameters.Add(new MySqlParameter("@password", EncodePassword(this.password)));
                    command.Parameters.Add(new MySqlParameter("@username", this.Username));
                    command.Parameters.Add(new MySqlParameter("@email", this.Email));
                    command.Parameters.Add(new MySqlParameter("@tel", this.Tel));
                    command.Parameters.Add(new MySqlParameter("@HireDate", DateTime.Now));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while inserting employee info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
