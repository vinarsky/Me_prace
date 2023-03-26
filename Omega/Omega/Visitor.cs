using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    class Visitor : Person
    {
        public Visitor(int id) : base(id)
        {
            this.id = id;
        }

        public bool Insert()
        {
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("insert into Visitor(firts_name, last_name, email, tel) values(@firts_name, @last_name, @email, @tel); ", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@firts_name", this.Firstname));
                    command.Parameters.Add(new MySqlParameter("@last_name", this.Lastname));
                    command.Parameters.Add(new MySqlParameter("@email", this.Email));
                    command.Parameters.Add(new MySqlParameter("@tel", this.Tel));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while inserting visitor info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
