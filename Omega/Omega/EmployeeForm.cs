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
        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        private Access neededLevel = Access.admin;

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

            foreach (KeyValuePair<string, int> entry in AccessDict)
            {
                names.Add(entry.Key);
            }
            RolesBox.DataSource = names;
        }

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

            FirstnameBox.Clear();
            LastnameBox.Clear();
            UsernameBox.Clear();
            EmailBox.Clear();
            TelnumBox.Value = 0;
            PasswordBox.Clear();

            if (User.Insert(AccessDict[RolesBox.SelectedItem.ToString()])) //pokud selže vložení do db, nepřidá se ani do listu
            {
                Users.Add(User);//Přdání do listu
                new Log("Added user: " + User.Username, MainPage.CurrentUser.Username);
            }                
            dataGridView.Refresh();
            source.ResetBindings(false);//Aktualizování tabulky
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {                        
            int row = dataGridView.SelectedCells[0].RowIndex;//nalezení řádku pro zmazání
            User UserToDelete = new User();//docasny object 

            if (dataGridView.SelectedCells[0].Value == null)//kontola zda zvolený řádek má nějaké hodnoty
                return;

            foreach (User u in Users)
            {
                if ((int)dataGridView.Rows[row].Cells[4].Value == u.ID)//nalezení objektu pro zmazání
                {
                    UserToDelete = u;
                }
            }

            if (UserToDelete.ID == MainPage.CurrentUser.ID)
            {
                MessageBox.Show("You can not remove the user you are currently loged in as!", "Error", button, icon);
                return;
            }

            DialogResult result = MessageBox.Show("Smazat " + UserToDelete.ToString() + "?", "Smazat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (UserToDelete.Delete()) //pokud delete z databáze neproběhne v pořádku neproběhne ani delete z listu
                { 

                    Users.Remove(UserToDelete);
                    new Log("deleted user: " + UserToDelete.Username, MainPage.CurrentUser.Username);
                }                    
                dataGridView.Refresh();//aktualizování
            }
        }

        private void dataGridView_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //zjištění políčka které bylo upraveno
            int row = dataGridView.SelectedCells[0].RowIndex;//řádek
            int column = dataGridView.SelectedCells[0].ColumnIndex;//sloupec
                                                                   
            foreach (User User in Users)
            {
                if ((int)dataGridView.Rows[row].Cells[4].Value == User.ID)//zjištění objektu který byl upraven
                {
                    User.Update(dataGridView.Columns[column].Name.ToString());                    
                }

                if (User.ID == MainPage.CurrentUser.ID)
                {
                    MainPage.CurrentUser = User;
                    UserPage displayedPage = (UserPage)Application.OpenForms["UserPage"]; //instance formu ktera je zobrazena
                    displayedPage.UpdateUserName();
                }
            }      
        }     
    }
}
