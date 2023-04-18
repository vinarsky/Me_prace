using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    public partial class NewReservationForm : Form
    {

        List<Visitor> VisitorsInRes = new List<Visitor>();
        List<Visitor> SearchedVisitors = new List<Visitor>();

        BindingSource SearchView = new BindingSource();
        BindingSource ResView = new BindingSource();

        public NewReservationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event that occures on first form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewReservationForm_Load(object sender, EventArgs e)
        {
            SearchView.DataSource = SearchedVisitors;
            SearchForPeople.DataSource = SearchView;
            ResView.DataSource = VisitorsInRes;
            PeopleInRes.DataSource = ResView;           
        }

        /// <summary>
        /// Event occures after create button is clicked. Creates a reservation a inserts it in to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateRes_Click(object sender, EventArgs e)
        {
            try
            {
                Room room = (Room)AvailableRooms.SelectedItem;
                Reservation res = new Reservation(dateTimeStart.Value, dateTimeEnd.Value, DateTime.Now, double.Parse(label7.Text), VisitorsInRes.Count, room.Id);
                res.Visitors = VisitorsInRes;
                res.Insert();
                MessageBox.Show("Reservaiton created!");
                new Log("created reservation: " + res.ToString(), MainPage.CurrentUser.Username);//log
                OverviewPage displayedPage = (OverviewPage)Application.OpenForms["OverviewPage"];
                displayedPage.Reload();
            }
            catch (Exception) 
            {
                MessageBox.Show("Error during creating reservaiton!", "Error");
            }
        }

        /// <summary>
        /// Event occures after remove button is clicked. It removes person from list of people in reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFromRes_Click(object sender, EventArgs e)
        {
            int row = 0;
            try
            {
                row = PeopleInRes.SelectedCells[0].RowIndex;
            }
            catch (ArgumentOutOfRangeException) { return; }          
            if (PeopleInRes.SelectedCells[0].Value == null)
                return;
            Visitor VisitorToDelete = VisitorsInRes.FirstOrDefault(u => u.ID == (int)PeopleInRes.Rows[row].Cells[0].Value);
            VisitorsInRes.Remove(VisitorToDelete);
            AvailableRooms.DataSource = new RoomDAO().GetRoomByCapacityDate(VisitorsInRes.Count, dateTimeStart.Value, dateTimeEnd.Value);
            ResView.ResetBindings(false);
            PeopleInRes.Refresh();
            CalculatePrice();
        }

        /// <summary>
        /// Event occures after add button is clicked. It adds person to the reservation from searched list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPersonToRes_Click(object sender, EventArgs e)
        {
            int row = 0;
            try
            {
                row = SearchForPeople.SelectedCells[0].RowIndex;
            }
            catch (ArgumentOutOfRangeException) { return; }
            if (SearchForPeople.SelectedCells[0].Value == null)
                return;
            Visitor VisitorToAdd = SearchedVisitors.FirstOrDefault(u => u.ID == (int)SearchForPeople.Rows[row].Cells[0].Value);
            if (!VisitorsInRes.Contains(VisitorToAdd))
            {
                VisitorsInRes.Add(VisitorToAdd);
                AvailableRooms.DataSource = new RoomDAO().GetRoomByCapacityDate(VisitorsInRes.Count, dateTimeStart.Value, dateTimeEnd.Value);
                ResView.ResetBindings(false);
                PeopleInRes.Refresh();
                CalculatePrice();
            }                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            SearchedVisitors = VisitorForm.Visitors.Where(r => r.Lastname.ToLower().StartsWith(SearchBar.Text.ToLower().ToString())).ToList();
            SearchView.DataSource = SearchedVisitors;
            SearchForPeople.DataSource = SearchView;
        }

        /// <summary>
        /// Calculates price of the accomodation based on amount od days and room's price per night.
        /// </summary>
        private void CalculatePrice()
        {
            if (AvailableRooms.SelectedItem == null)
                return;            
            TimeSpan days = dateTimeEnd.Value.Subtract(dateTimeStart.Value);
            Room room = (Room)AvailableRooms.SelectedItem;
            double price = (double)days.Days * room.PriceForNight;
            label7.Text = price.ToString();
        }

        /// <summary>
        /// When user selects a room, the price is recalculated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AvailableRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        /// <summary>
        /// When user changes end date of the reservation. The price and list off available rooms in the selected date changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            CalculatePrice();
            AvailableRooms.DataSource = new RoomDAO().GetRoomByCapacityDate(VisitorsInRes.Count, dateTimeStart.Value, dateTimeEnd.Value);
        }

        /// <summary>
        /// When user changes start date of the reservation. The price and list off available rooms in the selected date changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            CalculatePrice();
            AvailableRooms.DataSource = new RoomDAO().GetRoomByCapacityDate(VisitorsInRes.Count, dateTimeStart.Value, dateTimeEnd.Value);
        }

        /// <summary>
        /// When user selects end date that is invalid (end date before start). Error message pops up and new date has to be inserted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimeEnd_Validating(object sender, CancelEventArgs e)
        {
            TimeSpan days = dateTimeEnd.Value.Subtract(dateTimeStart.Value);
            if (days.Days < 0)
            {
                e.Cancel = true;
                MessageBox.Show("Invalid date", "Error");
            }
        }

        /// <summary>
        /// When user selects start date that is invalid (start date after end). Error message pops up and new date has to be inserted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimeStart_Validating(object sender, CancelEventArgs e)
        {
            TimeSpan days = dateTimeEnd.Value.Subtract(dateTimeStart.Value);
            if (days.Days < 0)
            {
                e.Cancel = true;
                MessageBox.Show("Invalid date", "Error");
            }
        }
    }
}
