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
                MessageBox.Show("Error while getting employees info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Visitors;
        }
    }
}
