using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    class UserDAO
    {
        public User GetUserByName(string name)
        {
            User User = null;
            try
            {               
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select username, password, firts_name, last_name, name, email, tel, Employee.id, hiredate from Employee inner join roles on roles.id = employee.role_id where username = @name;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@name", name));
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        User = new User(Convert.ToInt32(reader[7]));
                        User.Username = reader[0].ToString();
                        User.Password = reader[1].ToString();
                        User.Firstname = reader[2].ToString();
                        User.Lastname = reader[3].ToString();
                        User.Email = reader[5].ToString();
                        User.Tel = Convert.ToInt32(reader[6]);
                        if (!(reader.IsDBNull(8)))
                            User.DateOfEmployment = DateTime.Parse(reader[8].ToString());
                        switch (reader[4].ToString())
                        {
                            case "admin":
                                User.Access = Access.admin;
                                break;
                            case "basic_access":
                                User.Access = Access.basic_access;
                                break;
                            case "restricted_access":
                                User.Access = Access.restricted_access;
                                break;
                        }
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting employee info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return User;
        }

        public List<User> GetAllUsers()
        {
            List<User> Users = new List<User>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select username, password, firts_name, last_name, name, email, tel, Employee.id, hiredate from Employee inner join roles on roles.id = employee.role_id", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User User = new User(Convert.ToInt32(reader[7]));
                        User.Username = reader[0].ToString();
                        User.Password = reader[1].ToString();
                        User.Firstname = reader[2].ToString();
                        User.Lastname = reader[3].ToString();
                        User.Email = reader[5].ToString();
                        User.Tel = Convert.ToInt32(reader[6]);
                        if (!(reader.IsDBNull(8)))
                            User.DateOfEmployment = DateTime.Parse(reader[8].ToString());
                        switch (reader[4].ToString())
                        {
                            case "admin":
                                User.Access = Access.admin;
                                break;
                            case "basic_access":
                                User.Access = Access.basic_access;
                                break;
                            case "restricted_access":
                                User.Access = Access.restricted_access;
                                break;
                        }
                        Users.Add(User);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting employees info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Users;
        }

        public Dictionary<string, int> GetAccess()
        {
            Dictionary<string, int> Access = new Dictionary<string, int>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select * from roles", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Access.Add(reader[1].ToString(), Convert.ToInt32(reader[0]));
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting rights names!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Access;
        }
    }
}
