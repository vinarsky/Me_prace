using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega
{
    public class Room
    {
        private int id;
        private string room_type;
        private int max_people;
        private string room_status;
        private double price_for_night;
        private int floor;
        private string view;
        private bool Balcony;
        private bool AC_unit;

        public Dictionary<string, int> Beds = new Dictionary<string, int>();        

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
        public string RoomType 
        {
            get { return room_type; }
            set { room_type = value; } 
        }
        public int MaxPeople
        {
            get { return max_people; }
            set { max_people = value; }
        }
        public string RoomStatus 
        {
            get { return room_status; }
            set { room_status = value; }
        }
        public double PriceForNight 
        {
            get { return price_for_night; }
            set { price_for_night = value; }
        }
        public int Floor 
        {
            get { return floor; }
            set { floor = value; }
        }
        public string View
        {
            get { return view; }
            set { view = value; }
        }
        public bool balcony 
        {
            get { return Balcony; }
            set { Balcony = value; }
        }
        public bool AcUnit 
        {
            get { return AC_unit; }
            set { AC_unit = value; }
        }

        public Room(int id, string room_type, int max_people, string room_status, double price, int floor, string view, bool balcony, bool aC_unit)
        {
            this.Id = id;
            this.RoomType = room_type;
            this.MaxPeople = max_people;
            this.RoomStatus = room_status;
            this.Floor = floor;
            this.View = view;
            this.balcony = balcony;
            this.AcUnit = aC_unit;
            this.PriceForNight = price;
        }

        public override string ToString()
        {
            return "ID: " + id + ", " + room_type + " " + floor;
        }
        public void UpdateStatus()
        {
            MySqlConnection conn = DataBaseConnection.GetConnection();
            using (MySqlCommand command = new MySqlCommand("update Room set room_status_id = (select id from Room_status where name = @name) where id = @id;", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", this.Id));
                command.Parameters.Add(new MySqlParameter("@name", this.RoomStatus));
                command.ExecuteNonQuery();
            }
        }
    }
}
