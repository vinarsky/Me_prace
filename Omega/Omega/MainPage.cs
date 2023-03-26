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
        //aktualne prihlaseny uzivatel
        public static User CurrentUser = null;

        //aktualne zobrazeny form
        Form CurrentForm = null;

        //Formulare 
        RoomPage Room = new RoomPage();
        OverviewPage Overview = new OverviewPage();
        UserPage User = new UserPage();
        EmployeeForm Employee = new EmployeeForm();
        VisitorForm Visitor = new VisitorForm();
        NewReservationForm NewReservation = new NewReservationForm();

        //Construktor
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tento even nastane kdyz se form nacte. Otevre se form overview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPage_Load(object sender, EventArgs e)
        {
            OpenSection(Overview);            
        }

        /// <summary>
        /// Metoda otevira Formy. Nastavi ho jako child panelu MainContent. Nastavi nadpis podle tagu formu
        /// </summary>
        /// <param name="Form">Formular ktery se ma otevrit</param>
        public void OpenSection(Form Form)
        {
            if (CurrentForm != null)            
                CurrentForm.Hide();
           
            CurrentForm = Form;
            Form.TopLevel = false;
            Form.FormBorderStyle = FormBorderStyle.None;
            Form.Dock = DockStyle.Fill;
            this.MainContent.Controls.Add(Form);
            this.MainContent.Tag = Form;
            Form.Show();
            Header.Text = Form.Tag.ToString();
        }

        //Nasledujci metody jsou eventy, ktere se spusti pri kliknuti na nejaky button z menu. Oteviraji se jimi jednotlive sekce

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
        /// Event ktery nastane po kliknuti na tlacitko 'Vypnout'. Nejdrive je uzivatel tazan, zda opravdu chce aplikaci vypnout.
        /// Pokud ne, metoda skonci. Pokud ano, aplikace se vypne.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vypnout aplikaci?", "Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        /// <summary>
        /// Event ktery nastane po kliknuti na tlacitko 'Odhlasit se'. Nejdrive je uzivatel tazan, zda se opravdu, chce odhlasit.
        /// Pokud ne, metoda skonci. Pokud ano, schova se hlavni menu, otevre se login stranka, zapise se do logu a Currentuser se nastavi na null
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
        }
    }
}
