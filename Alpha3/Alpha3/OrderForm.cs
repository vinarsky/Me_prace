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
    public partial class OrderForm : Form
    {
        List<Order> Orders = new List<Order>();

        OrderDAO ODAO = new OrderDAO();

        BindingSource source = new BindingSource();
        BindingSource source1 = new BindingSource();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            //naplnění listu daty a vložení do tabulky
            Orders = ODAO.GetAllOrders();
            source.DataSource = Orders;
            dataGridView.DataSource = source;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;//nastavení aby šlo zvolit pouze jedno políčko
            dataGridView.Columns[0].Visible = false;//schování ID
            dataGridView.Columns["EntirePrice"].Visible = false;//schování celkové ceny
            foreach (DataGridViewColumn c in dataGridView.Columns)
            {
                c.ReadOnly = true;//nastavení aby žádný ze sloupců nešel editovat
            }
        }
        /// <summary>
        /// Event který nastene při kliknutí na některé políčko, zjistí se jaká objednávka je na tom řádku kde je to políčku a v postraní tabluce vyběhou produkty v dané objednávce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;//nalezení řádku
            if (dataGridView.SelectedCells[0].Value == null)
                return;//kontola zda zvolený řádek má nějaké hodnoty
            foreach (Order or in Orders)
            {
                if ((int)dataGridView.Rows[row].Cells[0].Value == or.ID)//nalezení objednávky jejíž produty se mají zobrazit
                {                    
                    source1.DataSource = or.orderedProducts;
                    OrderProducts.DataSource = source1;
                }
            }
        }
    }
}
