using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha3
{
    public partial class StoreForm : Form
    {
        List<Store> Stores = new List<Store>();

        StoreDAO SDAO = new StoreDAO();
        BindingSource source = new BindingSource();
        BindingSource source1 = new BindingSource();
        public StoreForm()
        {
            InitializeComponent();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            Stores = SDAO.GetAllStores();//naplnění listu daty a vložení do tabulky
            source.DataSource = Stores;
            dataGridView.DataSource = source;
            foreach (DataGridViewColumn c in dataGridView.Columns)
            {
                c.ReadOnly = true;//nastavení aby žádný ze sloupců nešel editovat
            }
        }
        /// <summary>
        /// Event který nastene při kliknutí na některé políčko, zjistí se jaká pobočka je na tom řádku kde je to políčku a v postraní tabluce vyběhou produkty a počet v dané pobočce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;//nalezení řádku
            if (dataGridView.SelectedCells[0].Value == null)
                return;//kontola zda zvolený řádek má nějaké hodnoty
            foreach (Store st in Stores)
            {
                if ((int)dataGridView.Rows[row].Cells[0].Value == st.ID)//nalezení pobočky jejíž produty s počty se mají zobrazit
                {
                    source1.DataSource = st.WarHouse;
                    Warhouse.DataSource = source1;
                }
            }
            Warhouse.Columns["product_id"].Visible = false;
        }
        /// <summary>
        /// Event kterýnastane při kliknutí na tlačítko 'Přesunout'. Metoda převádí produkty z jednoho skladu do druhého pomocí procedůry v DB. Vim je to nested humus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferButton_Click(object sender, EventArgs e)
        {
            int rowProduct = dataGridView.SelectedCells[0].RowIndex;
            int rowStore = Warhouse.SelectedCells[0].RowIndex;
            if (dataGridView.SelectedCells[0].Value == null)
                return;//kontola zda zvolený řádek má nějaké hodnoty
            if (Warhouse.SelectedCells[0].Value == null)
                return;//kontola zda zvolený řádek má nějaké hodnoty
            foreach (Store st in Stores)
            {
                if ((int)dataGridView.Rows[rowProduct].Cells[0].Value == st.ID)//nalezení pobočky jejíž produkty se mají zobrazit
                {
                    foreach (StoredItems item in st.WarHouse)
                    {
                        if (Warhouse.Rows[rowStore].Cells[0].Value.ToString() == item.Product.ToString())//nalezení produktu který se má odvézt
                        {
                            MySqlConnection conn = DatabaseConnection.GetConnection();
                            using (MySqlCommand command = new MySqlCommand("CALL Prevoz_zbozi_na_jinou_pobocku (@kam, @odkud, @produkt, @pocet)", conn))
                            {
                                command.Parameters.Add(new MySqlParameter("@kam", (int)ToWhichStore.Value));
                                command.Parameters.Add(new MySqlParameter("@odkud", st.ID));
                                command.Parameters.Add(new MySqlParameter("@produkt", item.Product.ID));
                                command.Parameters.Add(new MySqlParameter("@pocet", (int)AmountToTransfer.Value));
                                command.ExecuteNonQuery();//Spuštění procedůry s parametry
                                Stores = SDAO.GetAllStores();//Aktualizace listu s pobočkami
                                source.DataSource = Stores;
                                dataGridView.DataSource = source;
                                dataGridView.Refresh();
                                Warhouse.Refresh();
                            }
                        }
                    }
                }
            }
        }
    }
}
