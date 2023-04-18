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
    public partial class RoomPage : Form
    {
        BindingSource source = new BindingSource();
        BindingSource BedsSource = new BindingSource();
        List<Room> Rooms = new List<Room>();
        RoomDAO RDAO = new RoomDAO();

        Dictionary<string, string> AvaliableFilters = new Dictionary<string, string>();
        Dictionary<string, string> AppliedFilters = new Dictionary<string, string>();

        public RoomPage()
        {
            InitializeComponent();
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomPage_Load(object sender, EventArgs e)
        {
            Rooms = RDAO.GetAllRooms();
            StatusList.DataSource = RDAO.GetRoomStatus();
            source.DataSource = Rooms;
            dataGridView.DataSource = source;
            AvaliableFilters = RDAO.GetRoomProperties();

            MinCena.Maximum = 1000;
            MaxCena.Maximum = 1000;

            AvailableFiltersList.DataSource = new List<string>(AvaliableFilters.Keys);
            AppliedFiltersList.DataSource = new List<string>(AppliedFilters.Keys);
        }

        /// <summary>
        /// Filtes the datagridview based on items in dict AppliedFilters
        /// </summary>
        public void Filter()
        {
            if (AppliedFilters.Count == 0)
            {
                dataGridView.DataSource = Rooms;
                return;
            }

            List<Room> filteredRooms = new List<Room>();

            foreach (var filter in AppliedFilters)
            {
                List<Room> TempRooms = new List<Room>();
                switch (filter.Value)
                {
                    case "Room_type":
                        TempRooms = Rooms.Where(r => r.RoomType == filter.Key).ToList();
                        break;
                    case "Room_status":
                        TempRooms = Rooms.Where(r => r.RoomStatus == filter.Key).ToList();
                        break;
                    case "Room_view":
                        TempRooms = Rooms.Where(r => r.View == filter.Key).ToList();
                        break;                        
                }
                TempRooms = TempRooms.Distinct().ToList();
                filteredRooms.AddRange(TempRooms);
            }
            if (PricecheckBox.Checked)
                filteredRooms = filteredRooms.Where(r => r.PriceForNight >= Convert.ToInt32(MinCena.Value) && r.PriceForNight <= Convert.ToInt32(MaxCena.Value)).ToList();
            if (FloorcheckBox.Checked)
                filteredRooms = filteredRooms.Where(r => r.Floor == Convert.ToInt32(Floor.Value)).ToList();

            dataGridView.DataSource = filteredRooms;

        }

        /// <summary>
        /// Refrehes listboxes after a change. Empties and then filles them with changed lists.
        /// </summary>
        public void RefreshList()
        {
            AvailableFiltersList.DataSource = null;
            AppliedFiltersList.DataSource = null;
            AvailableFiltersList.DataSource = new List<string>(AvaliableFilters.Keys);
            AppliedFiltersList.DataSource = new List<string>(AppliedFilters.Keys);
        }

        /// <summary>
        /// Event that aguires after a user clicks Add button to add filter from availablefilters to appliedfilters. It adds filter to applied filtee list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFilter_Click(object sender, EventArgs e)
        {
            if (AvailableFiltersList.SelectedItem == null)
                return;
            AppliedFilters.Add(AvailableFiltersList.SelectedItem.ToString(), AvaliableFilters[AvailableFiltersList.SelectedItem.ToString()]);
            AvaliableFilters.Remove(AvailableFiltersList.SelectedItem.ToString());
            RefreshList();
        }

        /// <summary>
        /// Event that aguires after a user clicks Remove button to remove filter from appliedfilters. It removes filter from applied filtee list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFiltr_Click(object sender, EventArgs e)
        {
            if (AppliedFiltersList.SelectedItem == null)
                return;
            AvaliableFilters.Add(AppliedFiltersList.SelectedItem.ToString(), AppliedFilters[AppliedFiltersList.SelectedItem.ToString()]);
            AppliedFilters.Remove(AppliedFiltersList.SelectedItem.ToString());
            RefreshList();
        }

        private void ApplieFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// event occures when user clicks row in datagridview, then right datagridview show types of beds in room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;
            Room room = Rooms.FirstOrDefault(r => r.Id == (int)dataGridView.Rows[row].Cells[0].Value);
            BedsSource.DataSource = room.Beds;
            BedsdataGridView.DataSource = BedsSource;
        }

        /// <summary>
        /// event occures when user clicks ChangeRoomStatus button, button changes the state of the room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeRoomState_Click(object sender, EventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;
            Room room = Rooms.FirstOrDefault(r => r.Id == (int)dataGridView.Rows[row].Cells[0].Value);
            room.RoomStatus = StatusList.SelectedItem.ToString();
            room.UpdateStatus();
            dataGridView.Refresh();
        }
    }
}
