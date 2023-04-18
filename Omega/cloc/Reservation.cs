using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    class Reservation
    {
        private int id;
        private DateTime start_date;
        private DateTime end_date;
        private DateTime date_reservation;
        private double total_price;
        private int amount_guests;
        private int room_id;
        private Room room;

        public List<Visitor> Visitors = new List<Visitor>();

        public int Id
        {
            get { return id; }
        }

        public DateTime StartDate
        {
            get { return start_date; }
        }
        public DateTime EndDate
        {
            get { return end_date; }
        }
        public DateTime DateReservation
        {
            get { return date_reservation; }
        }
        public double TotalPrice
        {
            get { return total_price; }
        }
        public double AmountGuests
        {
            get { return amount_guests; }
        }

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }

        public int Room_id
        {
            get { return room_id; }
        }

        public Reservation(int id, DateTime starts_date, DateTime ends_date, DateTime date_reservation, double total_price, int amount_guests, int room_id)
        {
            this.id = id;
            this.start_date = starts_date;
            this.end_date = ends_date;
            this.date_reservation = date_reservation;
            this.total_price = total_price;
            this.amount_guests = amount_guests;
            this.room_id = room_id;
        }
        public Reservation(DateTime starts_date, DateTime ends_date, DateTime date_reservation, double total_price, int amount_guests, int room_id)
        {   
            this.start_date = starts_date;
            this.end_date = ends_date;
            this.date_reservation = date_reservation;
            this.total_price = total_price;
            this.amount_guests = amount_guests;
            this.room_id = room_id;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + ", from " + start_date + " till " + end_date + ", made on " + date_reservation;
        }

        /// <summary>
        /// Inserts reservation in to a database
        /// </summary>
        /// <returns>returns true if successful, othervise false</returns>
        public void Insert()
        {
            try
            {
                MySqlConnection conn = DataBaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("insert into reservation(starts, ends, date_reservation, total_price, amount_guests, room_id) values(@start, @end, @date_reservation, @total_price, @amount_guests, @room_id); ", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@start", this.start_date));
                    command.Parameters.Add(new MySqlParameter("@end", this.end_date));
                    command.Parameters.Add(new MySqlParameter("@date_reservation", this.date_reservation));
                    command.Parameters.Add(new MySqlParameter("@total_price", this.total_price));
                    command.Parameters.Add(new MySqlParameter("@amount_guests", this.amount_guests));
                    command.Parameters.Add(new MySqlParameter("@room_id", this.room_id));
                    command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand("Select @@Identity", conn))
                {
                    this.id = Convert.ToInt32(command.ExecuteScalar());
                }
                foreach (Visitor v in this.Visitors)
                {
                    using (MySqlCommand command = new MySqlCommand("update visitor set res_id = @id where id = @vis_id", conn))
                    {
                        command.Parameters.Add(new MySqlParameter("@id", this.id));
                        command.Parameters.Add(new MySqlParameter("@vis_id", v.ID));
                        command.ExecuteNonQuery();
                    }
                }
                DataBaseConnection.Commit();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while inserting reservation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
