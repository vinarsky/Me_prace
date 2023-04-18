using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega.DAOs
{
    class ReservationDAO
    {
        public Reservation GetReservationByID(int id)
        {
            Reservation res = null;
            RoomDAO RDAO = new RoomDAO();
            VisitorDAO VDAO = new VisitorDAO();
            MySqlConnection conn = DataBaseConnection.GetConnection();
            try
            {
                using (MySqlCommand Command = new MySqlCommand("select * from reservation where id = @id;", conn))
                {
                    Command.Parameters.Add(new MySqlParameter("@id", id));
                    MySqlDataReader reader = Command.ExecuteReader();
                    if (reader.Read())
                    {
                        res = new Reservation(
                            Convert.ToInt32(reader[0]),
                            DateTime.Parse(reader[1].ToString()),
                            DateTime.Parse(reader[2].ToString()),
                            DateTime.Parse(reader[3].ToString()),
                            double.Parse(reader[4].ToString()),
                            Convert.ToInt32(reader[5].ToString()),
                            Convert.ToInt32(reader[6].ToString())
                            );
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting reservation info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }

        public List<Reservation> GetAllReservations(string clause)
        {
            List<Reservation> Reservations = new List<Reservation>();
            RoomDAO RDAO = new RoomDAO();
            VisitorDAO VDAO = new VisitorDAO();
            MySqlConnection conn = DataBaseConnection.GetConnection();
            try
            {
                using (MySqlCommand Command = new MySqlCommand("select * from reservation" + clause, conn))
                {
                    MySqlDataReader reader = Command.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservation res = new Reservation(
                            Convert.ToInt32(reader[0]),
                            DateTime.Parse(reader[1].ToString()),
                            DateTime.Parse(reader[2].ToString()),
                            DateTime.Parse(reader[3].ToString()),
                            double.Parse(reader[4].ToString()),
                            Convert.ToInt32(reader[5].ToString()),
                            Convert.ToInt32(reader[6].ToString())
                            );
                        Reservations.Add(res);                        
                    }
                    reader.Close();
                }
                foreach(Reservation res in Reservations)
                {
                    res.Room = RDAO.GetRoomByID(res.Room_id);
                    res.Visitors = VDAO.GetVisitorByResId(res.Id);
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting reservations info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Reservations;
        }        
    }
}
