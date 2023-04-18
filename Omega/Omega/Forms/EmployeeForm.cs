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
    public partial class EmployeeForm : Form
    {
        private Access neededLevel = Access.admin;//needes acces level to view this page

        public Access NeededLevel
        {
            get { return neededLevel; }
        }

        BindingSource source = new BindingSource();
        UserDAO UDAO = new UserDAO();

        List<User> Users = new List<User>();
        Dictionary<string, int> AccessDict = new Dictionary<string, int>();

        public EmployeeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// occurs on first form load, filles in the all employees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            TelnumBox.Maximum = 999999999;
            AccessDict = UDAO.GetAccess();
            Users = UDAO.GetAllUsers();
            source.DataSource = Users;
            dataGridView.DataSource = source;

            dataGridView.Columns["Password"].Visible = false;
            dataGridView.Columns["ID"].DisplayIndex = 0;
            dataGridView.Columns["dateOfEmployment"].ReadOnly = true;
            dataGridView.Columns["Username"].ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;//nastavení aby šlo zvolit pouze jedno políčko

            List<string> names = new List<string>();
            //filles in the priviliges name
            foreach (KeyValuePair<string, int> entry in AccessDict)
            {
                names.Add(entry.Key);
            }
            RolesBox.DataSource = names;
        }

        /// <summary>
        /// adds employee in to array and database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            User User = new User();
            User.Firstname = FirstnameBox.Text;
            User.Lastname = LastnameBox.Text;
            User.Username = UsernameBox.Text;
            User.Email = EmailBox.Text;
            User.Tel = Convert.ToInt32(TelnumBox.Value);
            User.Password = PasswordBox.Text;
            User.DateOfEmployment = DateTime.Today;

            switch (RolesBox.SelectedItem)
            {
                case "admin":
                    User.Access = Access.admin;
                    break;
                case "basic_access":
                    User.Access = Access.basic_access;
                    break;
                case "restricted_access":
                    User.Access = Access.restricted_access;
                    break;
            }

            FirstnameBox.Clear();
            LastnameBox.Clear();
            UsernameBox.Clear();
            EmailBox.Clear();
            TelnumBox.Value = 0;
            PasswordBox.Clear();

            if (User.Insert(AccessDict[RolesBox.SelectedItem.ToString()])) //if adding in to database fails, it doenst add to the array of employees
            {
                Users.Add(User);
                new Log("Added user: " + User.Username, MainPage.CurrentUser.Username);//log
                source.ResetBindings(false);//datagridview refresh
            }                         
        }

        /// <summary>
        /// deletes selected employee from array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {                                    
            if (dataGridView.SelectedCells[0].Value == null)//checks if selected row has a value
                return;

            int row = dataGridView.SelectedCells[0].RowIndex;
            User UserToDelete = Users.FirstOrDefault(u => u.ID == (int)dataGridView.Rows[row].Cells[4].Value);//findes selected user

            if (UserToDelete.ID == MainPage.CurrentUser.ID)//you cant deleted user you are currently loged in as
            {
                MessageBox.Show("You can not remove the user you are currently loged in as!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Smazat " + UserToDelete.ToString() + "?", "Smazat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)//conformation from user
            {
                if (UserToDelete.Delete()) //if delete from database fails, it doesnt delete it from the array
                { 
                    Users.Remove(UserToDelete);
                    new Log("deleted user: " + UserToDelete.Username, MainPage.CurrentUser.Username);
                    dataGridView.Refresh();
                }                                    
            }
        }

        /// <summary>
        /// event occurs when there is an error in datagridview, this ensures that program doesnt crash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// event occurs when you finish cell edit with pressing enter, updates the changed column in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;
            int column = dataGridView.SelectedCells[0].ColumnIndex;
            User TempUser = Users.FirstOrDefault(u => u.ID == (int)dataGridView.Rows[row].Cells[4].Value);//gets the user whose values was changed
            TempUser.Update(dataGridView.Columns[column].Name.ToString());

            if (TempUser.ID == MainPage.CurrentUser.ID)//if user is changing his values, it will be updated in user page
            {
                MainPage.CurrentUser = TempUser;
                UserPage displayedPage = (UserPage)Application.OpenForms["UserPage"];
                if (displayedPage == null)
                    return;
                displayedPage.UpdateUserName();
            }
        }

        /// <summary>
        /// occurs when user clicks the 'Upravit roli' button, changes the role of selected employee in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeRole_Click(object sender, EventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;
            if (dataGridView.SelectedCells[0].Value == null)//checks if selected row has a value
                return;

            User p = Users.FirstOrDefault(u => u.ID == (int)dataGridView.Rows[row].Cells[4].Value);//gets selected employee

            switch (RolesBox.SelectedItem)
            {
                case "admin":
                    p.Access = Access.admin;
                    break;
                case "basic_access":
                    p.Access = Access.basic_access;
                    break;
                case "restricted_access":
                    p.Access = Access.restricted_access;
                    break;
            }
            p.UpdateRole();
            dataGridView.Refresh();    
        }
    }
}
