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
    public partial class OverviewPage : Form
    {
        BindingSource NextWeekRes = new BindingSource();
        BindingSource CurentWeekRes = new BindingSource();
        BindingSource VisitorsInRes = new BindingSource();
        DAOs.ReservationDAO RDAO = new DAOs.ReservationDAO();

        List<Reservation> ReservationsForNextWeek = new List<Reservation>();
        List<Reservation> CurrentReservations = new List<Reservation>();

        public OverviewPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// occures on first form load, filles in reservations in datagridviews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverviewPage_Load(object sender, EventArgs e)
        {
            ReservationsForNextWeek = RDAO.GetAllReservations(" where starts between CURRENT_DATE() and CURRENT_DATE() + 7;");
            CurrentReservations = RDAO.GetAllReservations(" where CURRENT_DATE() between starts and ends;");

            NextWeekRes.DataSource = ReservationsForNextWeek;
            dataGridView.DataSource = NextWeekRes;
            CurentWeekRes.DataSource = CurrentReservations;
            dataGridViewCurrent.DataSource = CurentWeekRes;

            dataGridView.Columns["room_id"].Visible = false;
            dataGridViewCurrent.Columns["room_id"].Visible = false;            

            dataGridView.ReadOnly = true;
            dataGridView.ReadOnly = true;
        }

        /// <summary>
        /// occures when user clicks a row in top datagridview, the right datagridview showes visitors in reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;
            Reservation res = ReservationsForNextWeek.FirstOrDefault(r => r.Id == (int)dataGridView.Rows[row].Cells[0].Value);
            VisitorsInRes.DataSource = res.Visitors;
            Visitors.DataSource = VisitorsInRes;
            Visitors.Columns["ID"].Visible = false;
        }

        /// <summary>
        /// occures when user clicks a row in bottom datagridview, the right datagridview showes visitors in reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCurrent_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            int row = dataGridViewCurrent.SelectedCells[0].RowIndex;
            Reservation res = CurrentReservations.FirstOrDefault(r => r.Id == (int)dataGridViewCurrent.Rows[row].Cells[0].Value);
            VisitorsInRes.DataSource = res.Visitors;
            Visitors.DataSource = VisitorsInRes;
            Visitors.Columns["ID"].Visible = false;
        }

        /// <summary>
        /// After inserting new reservation, the page is reloaded with newest data
        /// </summary>
        public void Reload()
        {
            ReservationsForNextWeek = RDAO.GetAllReservations(" where starts between CURRENT_DATE() and CURRENT_DATE() + 7;");
            CurrentReservations = RDAO.GetAllReservations(" where CURRENT_DATE() between starts and ends;");
            NextWeekRes.DataSource = ReservationsForNextWeek;
            dataGridView.DataSource = NextWeekRes;
            CurentWeekRes.DataSource = CurrentReservations;
            dataGridViewCurrent.DataSource = CurentWeekRes;
        }
    }
}
