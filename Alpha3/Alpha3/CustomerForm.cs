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
    public partial class CustomerForm : Form
    {
        List<Customer> Customers = new List<Customer>();

        CustomerDAO CDAO = new CustomerDAO();
        BindingSource source = new BindingSource();

        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxButtons button = MessageBoxButtons.YesNo;
        MessageBoxIcon icon = MessageBoxIcon.Question;

        MessageBoxIcon iconError = MessageBoxIcon.Error;
        MessageBoxButtons buttonOK = MessageBoxButtons.OK;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            //naplnění listu daty a vložení do tabulky
            Customers = CDAO.GetAllCustomers();
            source.DataSource = Customers;
            dataGridView.DataSource = source;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect; //nastavení aby šlo zvolit pouze jedno políčko
            dataGridView.Columns[0].Visible = false;    //schování ID
        }

        /// <summary>
        /// Event který nastane když klávesou Enter ukončím edit nějakého z políček, zjistí řádek a sloupec, kde k úpravě došlo. Object, který má být upraven, se slopcem, který má být upraven, se pošle do metody ColumnToUpdate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //zjištění políčka které bylo upraveno
            int row = dataGridView.SelectedCells[0].RowIndex; //řádek
            int column = dataGridView.SelectedCells[0].ColumnIndex; //sloupec
            foreach (Customer c in Customers)
            { 
                if ((int)dataGridView.Rows[row].Cells[0].Value == c.ID)//zjištění objektu který byl upraven
                {
                    //zavolání metody ColumnToUpdate, která pak už volá přímo metody které upravý data v databázi
                    ColumnToUpdate(c, dataGridView.Columns[column].Name.ToString());
                }
            }
        }
        /// <summary>
        /// Metoda vezme nazev sloupce a podle něho zavolá příslušnou metodu, která provede změny v DB daného zápisu
        /// </summary>
        /// <param name="c">Objekt který se má v DB upravit</param>
        /// <param name="column">sloupce který se má upravit</param>
        private void ColumnToUpdate(Customer c, string column)
        {
            switch (column)
            {
                case "Firstname":
                    c.UpdateFname();
                    break;
                case "Lastname":
                    c.UpdateLname();
                    break;
                case "Email":
                    c.UpdateEmail();
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
                Customer CustomerToDelete = new Customer();//docasny object 
                if (dataGridView.SelectedCells[0].Value == null)
                    return;//kontola zda zvolený řádek má nějaké hodnoty
                foreach (Customer em in Customers)
                {
                    if ((int)dataGridView.Rows[row].Cells[0].Value == em.ID)
                    {
                        CustomerToDelete = em;//nalezení objektu pro zmazání
                    }
                }
                DialogResult result = MessageBox.Show("Smazat " + CustomerToDelete.ToString() + "?", "Smazat", button, icon);
                if (result == DialogResult.Yes)
                {
                    if(CustomerToDelete.Delete())//pokud delete z databáze neproběhne v pořádku neproběhne ani delete z listu
                        Customers.Remove(CustomerToDelete);
                    dataGridView.Refresh();//aktualizování
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while deleting customer!", "Error", buttonOK, iconError);
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
    }
}
