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
        /// <summary>
        /// Gets all rooms from database
        /// </summary>
        /// <returns>List of rooms</returns>
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
                using (MySqlCommand command = new MySqlCommand("select * from room_bed inner join bed_type on bed_type.id = room_bed.bed_type_id;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = Rooms.Find(r => r.Id == Convert.ToInt32(reader[1]));
                        if (room != null)
                            room.Beds.Add(reader[5].ToString(), Convert.ToInt32(reader[3]));
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting rooms info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Rooms;
        }

        /// <summary>
        /// gets a room by id
        /// </summary>
        /// <param name="id">id that the return room should have</param>
        /// <returns>room with the id</returns>
        public Room GetRoomByID(int id)
        {
            Room room = null;
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select room.id, room.max_people, room.price_for_night, room.floor, balcony, AC_unit, room_view.name as v, room_type.name as type, room_status.name as stat from room inner join room_type on room_type.id = room.room_type_id inner join room_status on room_status.id = room.room_status_id inner join room_view on room_view.id = room.view_id where room.id = @id order by room.id; ", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", id));
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        room = new Room(
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
                    }
                    reader.Close();
                }
                using (MySqlCommand command = new MySqlCommand("select * from room_bed inner join bed_type on bed_type.id = room_bed.bed_type_id where room_id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", room.Id));
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        room.Beds.Add(reader[5].ToString(), Convert.ToInt32(reader[3]));
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting room info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return room;
        }

        /// <summary>
        /// Gets all properties of rooms for which other tables are used
        /// </summary>
        /// <returns>
        /// Dictionary that contains values and keys. Keys are all options of an atribute. 
        /// Values are names of the atribute. Dict is used for room filtration.
        /// Example: key=occupied, value=status | key=out of service, value=status | key=sea, value=view | key=city, values=view
        /// </returns>
        public Dictionary<string, string> GetRoomProperties()
        {
            Dictionary<string, string> Properties = new Dictionary<string, string>();
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select name from Room_type;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Properties.Add(reader[0].ToString(), "Room_type");
                    }
                    reader.Close();
                }
                using (MySqlCommand command = new MySqlCommand("select name from Room_status;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Properties.Add(reader[0].ToString(), "Room_status");
                    }
                    reader.Close();
                }
                using (MySqlCommand command = new MySqlCommand("select name from Room_view;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Properties.Add(reader[0].ToString(), "Room_view");
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting rooms info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Properties;
        }

        /// <summary>
        /// gets list of all stats a room can have
        /// </summary>
        /// <returns></returns>
        public List<string> GetRoomStatus()
        {
            List<string> Status = new List<string>();
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("select name from Room_status;", conn))
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Status.Add(reader[0].ToString());
                }
                reader.Close();
            }
            return Status;
        }

        public List<Room> GetRoomByCapacityDate(int capacity, DateTime start, DateTime end)
        {
            List<Room> Rooms = new List<Room>();
            //try
            //{
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select * from RoomSelect WHERE max_people = @cap and id NOT IN (SELECT room_id FROM reservation WHERE((starts <= @endDate AND ends >= @startDate)OR(starts >= @startDate AND ends <= @endDate)OR(starts <= @endDate AND ends >= @endDate)));", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@cap", capacity));
                    command.Parameters.Add(new MySqlParameter("@endDate", end));
                    command.Parameters.Add(new MySqlParameter("@startDate", start));
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
                using (MySqlCommand command = new MySqlCommand("select * from room_bed inner join bed_type on bed_type.id = room_bed.bed_type_id;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = Rooms.Find(r => r.Id == Convert.ToInt32(reader[1]));
                        if (room != null)
                            room.Beds.Add(reader[5].ToString(), Convert.ToInt32(reader[3]));
                    }
                    reader.Close();
                }
            //}
            //catch (MySqlException)
            //{
            //    MessageBox.Show("Error while getting rooms info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            return Rooms;
        }        
    }
}
