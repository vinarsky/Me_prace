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
        List<Room> Rooms = new List<Room>();
        RoomDAO RDAO = new RoomDAO();

        List<string> AvaliableFilters = new List<string>();
        List<string> AppliedFilters = new List<string>();

        public RoomPage()
        {
            InitializeComponent();
        }

        private void RoomPage_Load(object sender, EventArgs e)
        {
            Rooms = RDAO.GetAllRooms();
            source.DataSource = Rooms;
            dataGridView.DataSource = source;
            AvaliableFilters = RDAO.GetRoomProperties();

            AvailableFiltersList.DataSource = AvaliableFilters;
            AppliedFiltersList.DataSource = AppliedFilters;
        }

        private void ApplieFilter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AddFilter_Click(object sender, EventArgs e)
        {
            if (AvailableFiltersList.SelectedItem == null)
                return;
            AppliedFilters.Add(AvailableFiltersList.SelectedItem.ToString());
            AvaliableFilters.Remove(AvailableFiltersList.SelectedItem.ToString());
            AvailableFiltersList.DataSource = null;
            AppliedFiltersList.DataSource = null;
            AvailableFiltersList.DataSource = AvaliableFilters;
            AppliedFiltersList.DataSource = AppliedFilters;
        }

        private void RemoveFiltr_Click(object sender, EventArgs e)
        {
            if (AppliedFiltersList.SelectedItem == null)
                return;
            AvaliableFilters.Add(AppliedFiltersList.SelectedItem.ToString());
            AppliedFilters.Remove(AppliedFiltersList.SelectedItem.ToString());
            AvailableFiltersList.DataSource = null;
            AppliedFiltersList.DataSource = null;
            AvailableFiltersList.DataSource = AvaliableFilters;
            AppliedFiltersList.DataSource = AppliedFilters;
        }
    }
}
