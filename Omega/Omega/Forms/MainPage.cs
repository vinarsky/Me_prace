using MySql.Data.MySqlClient;
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
    public partial class MainPage : Form
    {
        //currently loged user 
        public static User CurrentUser = null;

        //currently viewed form
        Form CurrentForm = null;

        //forms
        RoomPage Room = new RoomPage();
        OverviewPage Overview = new OverviewPage();
        UserPage User = new UserPage();
        EmployeeForm Employee = new EmployeeForm();
        VisitorForm Visitor = new VisitorForm();
        NewReservationForm NewReservation = new NewReservationForm();

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event occuers on first form load, showed the overview form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPage_Load(object sender, EventArgs e)
        {
            OpenSection(Overview);
            VisitorForm.Visitors = new VisitorDAO().GetAllVisitors();
        }

        /// <summary>
        /// method opens forms in the left panel
        /// </summary>
        /// <param name="Form">form to open</param>
        public void OpenSection(Form Form)
        {
            if (CurrentForm != null)            
                CurrentForm.Hide();
           
            CurrentForm = Form;
            Form.TopLevel = false;//form will be on the same level as mainpage
            Form.FormBorderStyle = FormBorderStyle.None;//hides border of form
            Form.Dock = DockStyle.Fill;//streches the form across the whole panel
            MainContent.Controls.Add(Form);//makes the form visible as a part of the panel
            Form.Show();
            Header.Text = Form.Tag.ToString();
        }

        //following button click events open certain from, each one is opening one form

        private void UserButton_Click(object sender, EventArgs e)
        {
            OpenSection(User);
        }
        private void RoomButton_Click(object sender, EventArgs e)
        {
            OpenSection(Room);
        }
        private void OverviewButton_Click(object sender, EventArgs e)
        {
            OpenSection(Overview);
        }
        private void NewResButton_Click(object sender, EventArgs e)
        {
            OpenSection(NewReservation);
        }
        private void EmployeeButton_Click(object sender, EventArgs e)
        {
            if (Employee.NeededLevel >= CurrentUser.Access)
                OpenSection(Employee);
            else
                MessageBox.Show("You do not have sufficient privileges to access");
        }
        private void GuestButton_Click(object sender, EventArgs e)
        {
            if (Visitor.NeededLevel >= CurrentUser.Access)
                OpenSection(Visitor);
            else
                MessageBox.Show("You do not have sufficient privileges to access");
        }

        /// <summary>
        /// An event that occurs after clicking the 'Vypnout' button. First, the user is asked if they really want to turn off the application.
        /// If not, the method ends. If yes, the application is turned off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vypnout aplikaci?", "Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                DataBaseConnection.Commit();
            }            
        }

        /// <summary>
        /// An event that occurs after clicking the 'Odhlásit se' button. First, the user is asked if they really want to log out.
        /// If not, the method ends. If yes, the main menu is hidden, the login page is opened, it is written to the log, and the Currentuser is set to null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Odhlásit se?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            this.Hide();           
            new LoginPage().Show();
            new Log("logout", MainPage.CurrentUser.Username);
            CurrentUser = null;
            DataBaseConnection.Commit();
        }
    }
}
