using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha3
{
    public partial class EmployeeForm : Form
    {
        List<Employee> Employees = new List<Employee>();

        EmployeeDAO EDAO = new EmployeeDAO();
        BindingSource source = new BindingSource();


        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxButtons button = MessageBoxButtons.YesNo;
        MessageBoxIcon icon = MessageBoxIcon.Question;

        MessageBoxIcon iconError = MessageBoxIcon.Error;
        MessageBoxButtons buttonOK = MessageBoxButtons.OK;

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            //naplnění listu daty a vložení do tabulky
            Employees = EDAO.GetAllEmployees();
            source.DataSource = Employees;
            dataGridView.DataSource = source;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;//nastavení aby šlo zvolit pouze jedno políčko
            dataGridView.Columns[1].Visible = false;    //schování ID
            dataGridView.Columns["dateOfEmployment"].DisplayIndex = 4;  //přerovnání sloupců
            dataGridView.Columns["dateOfEmployment"].ReadOnly = true; //zamezení úpravi kategorie      
        }
        /// <summary>
        /// Event který nastane když klávesou Enter ukončím edit nějakého z políček, zjistí řádek a sloupec, kde k úpravě došlo. Object, který má být upraven, se slopcem, který má být upraven, se pošle do metody ColumnToUpdate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //zjištění políčka které bylo upraveno
            int row = dataGridView.SelectedCells[0].RowIndex;//řádek
            int column = dataGridView.SelectedCells[0].ColumnIndex;//sloupec
            foreach (Employee em in Employees)
            {
                if ((int)dataGridView.Rows[row].Cells[1].Value == em.ID)//zjištění objektu který byl upraven
                {
                    //zavolání metody ColumnToUpdate, která pak už volá přímo metody které upravý data v databázi
                    ColumnToUpdate(em, dataGridView.Columns[column].Name.ToString());
                }
            }
        }
        /// <summary>
        /// Metoda vezme nazev sloupce a podle něho zavolá příslušnou metodu, která provede změny v DB daného zápisu
        /// </summary>
        /// <param name="em">Objekt který se má v DB upravit</param>
        /// <param name="column">sloupce který se má upravit</param>
        private void ColumnToUpdate(Employee em, string column)
        {
            switch (column)
            {
                case "Firstname":
                    em.UpdateFname();
                    break;
                case "Lastname":
                    em.UpdateLname();
                    break;
                case "Email":
                    em.UpdateEmail();
                    break;
            }
        }
        /// <summary>
        /// Event který nastane při kliknutí delete buttnu, zjistí se jaký řádek byl zvolen při koliknutí na tlačítko, object který na řádku byl se smaže
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView.SelectedCells[0].RowIndex;//nalezení řádku pro zmazání
                Employee EmployeeToDelete = new Employee();//docasny object 
                if (dataGridView.SelectedCells[0].Value == null)//kontola zda zvolený řádek má nějaké hodnoty
                    return;
                foreach (Employee em in Employees)
                {
                    if ((int)dataGridView.Rows[row].Cells[1].Value == em.ID)//nalezení objektu pro zmazání
                    {
                        EmployeeToDelete = em;
                    }
                }
                DialogResult result = MessageBox.Show("Smazat " + EmployeeToDelete.ToString() + "?", "Smazat", button, icon);
                if (result == DialogResult.Yes)
                {
                    if(EmployeeToDelete.Delete())//pokud delete z databáze neproběhne v pořádku neproběhne ani delete z listu
                        Employees.Remove(EmployeeToDelete);
                    dataGridView.Refresh();//aktualizování
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while deleting employee!", "Error", buttonOK, iconError);
            }
        }
        /// <summary>
        /// Z nějakého důvodu to bez tohodle nefunguje idk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {      
            e.Cancel = true;
        }
        /// <summary>
        /// Event nastane při kliknutí na 'Přidat' button. Vezmou se hodnotu z text boxů a daj se nově vytvořenému objektu. Vloží se do DB, do listu a text boxy se vyčistí
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Firstname = FirstnameBox.Text;
            employee.Lastname = LastnameBox.Text;
            employee.Email = EmailBox.Text;
            employee.DateOfEmployment = DateTime.Now;
            FirstnameBox.Clear();
            LastnameBox.Clear();
            EmailBox.Clear();
            if(employee.Create())//pokud selže vložení do db, nepřidá se ani do listu
                Employees.Add(employee);//Přdání do listu
            dataGridView.Refresh();
            source.ResetBindings(false);//Aktualizování tabulky
        }
    }
}
