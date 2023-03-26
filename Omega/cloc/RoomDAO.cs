using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    class RoomDAO
    {
        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        public List<Room> GetAllRooms()
        {
            List<Room> Rooms = new List<Room>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select * from RoomSelect;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room R = new Room(
                            Convert.ToInt32(reader[0]),
                            reader[7].ToString(),
                            Convert.ToInt32(reader[1]),
                            reader[8].ToString(),
                            Convert.ToDouble(reader[2]),
                            Convert.ToInt32(reader[3]),
                            reader[6].ToString(),
                            Convert.ToBoolean(reader[4]),
                            Convert.ToBoolean(reader[5])
                            );
                        Rooms.Add(R);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting rooms info!", "Error", button, icon);
            }
            return Rooms;
        }

        public List<string> GetRoomProperties()
        {
            List<string> Properties = new List<string>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select name from Room_type;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Properties.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
                using (MySqlCommand command = new MySqlCommand("select name from Room_status;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Properties.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
                using (MySqlCommand command = new MySqlCommand("select name from Room_view;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Properties.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting rooms info!", "Error", button, icon);
            }
            return Properties;
        }
    }
}
