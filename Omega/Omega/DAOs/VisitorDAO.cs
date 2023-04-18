using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    class VisitorDAO
    {
        public List<Visitor> GetAllVisitors()
        {
            List<Visitor> Visitors = new List<Visitor>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select * from Visitor;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Visitor Visitor = new Visitor(Convert.ToInt32(reader[0]));
                        Visitor.Firstname = reader[1].ToString();
                        Visitor.Lastname = reader[2].ToString();
                        Visitor.Email = reader[3].ToString();
                        Visitor.Tel = Convert.ToInt32(reader[4]);
                        Visitors.Add(Visitor);
                    }
                    reader.Close();
                }                
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting visitor info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Visitors;
        }

        public List<Visitor> GetVisitorByResId(int id)
        {
            List<Visitor> Visitors = new List<Visitor>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select * from visitor where visitor.res_id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", id));
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Visitor Visitor = new Visitor(Convert.ToInt32(reader[0]));
                        Visitor.Firstname = reader[1].ToString();
                        Visitor.Lastname = reader[2].ToString();
                        Visitor.Email = reader[3].ToString();
                        Visitor.Tel = Convert.ToInt32(reader[4]);                        
                        Visitors.Add(Visitor);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting visitor info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Visitors;
        }
        public List<Visitor> GetVisitorsByLastName(string Lastname)
        {
            List<Visitor> Visitors = new List<Visitor>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select * from visitor where lower(visitor.last_name) like '@string%';", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@string", Lastname));
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Visitor Visitor = new Visitor(Convert.ToInt32(reader[0]));
                        Visitor.Firstname = reader[1].ToString();
                        Visitor.Lastname = reader[2].ToString();
                        Visitor.Email = reader[3].ToString();
                        Visitor.Tel = Convert.ToInt32(reader[4]);
                        Visitors.Add(Visitor);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting visitor info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Visitors;
        }
    }
}
