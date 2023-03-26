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
    public partial class ProductForm : Form
    {
        List<Product> Products = new List<Product>();

        ProductDAO PDAO = new ProductDAO();
        BindingSource source = new BindingSource();
        BindingSource source1 = new BindingSource();

        //objekty se používají u vyskakovacích okének, když se něco nepovede(error), nebo uživatel musí něco potvrdit
        MessageBoxButtons button = MessageBoxButtons.YesNo;
        MessageBoxIcon icon = MessageBoxIcon.Question;

        MessageBoxIcon iconerror = MessageBoxIcon.Error;
        MessageBoxButtons buttonok = MessageBoxButtons.OK;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            //naplnění listu daty a vložení do tabulky
            Products = PDAO.GetAllProducts();
            source.DataSource = Products;
            dataGridView.DataSource = source;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;//nastavení aby šlo zvolit pouze jedno políčko
            dataGridView.Columns[0].Visible = false;    //schování ID
            dataGridView.Columns["kategori"].ReadOnly = true;   //zamezení úpravi kategorie
            source1.DataSource = PDAO.GetAllKategori();//vložení dat do menu pro zlovení kategorie při ukládání nového produktu
            Kategories.DataSource = source1;            
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
            foreach (Product p in Products)
            {
                if ((int)dataGridView.Rows[row].Cells[0].Value == p.ID)//zjištění objektu který byl upraven
                {
                    //zavolání metody ColumnToUpdate, která pak už volá přímo metody které upravý data v databázi
                    ColumnToUpdate(p, dataGridView.Columns[column].Name.ToString());
                }
            }
        }
        /// <summary>
        /// Metoda vezme nazev sloupce a podle něho zavolá příslušnou metodu, která provede změny v DB daného zápisu
        /// </summary>
        /// <param name="p">Objekt který se má v DB upravit</param>
        /// <param name="column">sloupce který se má upravit</param>
        private void ColumnToUpdate(Product p, string column)
        {
            switch (column)
            {
                case "Name":
                    p.Updatename();
                    break;
                case "Price":
                    p.Updateprice();
                    break;
                case "Weight":
                    p.Updateweight();
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
                Product ProductToDelete = new Product();//docasny object 
                if (dataGridView.SelectedCells[0].Value == null)//kontola zda zvolený řádek má nějaké hodnoty
                    return;
                foreach (Product p in Products)
                {
                    if ((int)dataGridView.Rows[row].Cells[0].Value == p.ID)
                    {
                        ProductToDelete = p;//nalezení objektu pro zmazání
                    }
                }
                DialogResult result = MessageBox.Show("Smazat " + ProductToDelete.ToString() + "?", "Smazat", button, icon);
                if (result == DialogResult.Yes)
                {
                    if(ProductToDelete.Delete())//pokud delete z databáze neproběhne v pořádku neproběhne ani delete z listu
                        Products.Remove(ProductToDelete);
                    dataGridView.Refresh();//aktualizování
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while deleting product!", "Error", button, icon);
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
            try
            {                
                Product p = new Product();
                p.Name = NameBox.Text;
                if (float.Parse(PriceBox.Text) < 1 || Convert.ToInt32(WeightBox.Text) < 1)
                    throw new Exception();
                p.Price = float.Parse(PriceBox.Text);
                p.Weight = Convert.ToInt32(WeightBox.Text);
                if (checkBox.Checked && NewKategori.Text != "")//Kontrola zda uživatel chce novou kategorii nebo z menu, aby se vzalá nová kategorie, text box nesmí být prázdný a checkbox musí být true
                    p.Kategori = NewKategori.Text;
                else
                    p.Kategori = Kategories.SelectedItem.ToString();
                WeightBox.Clear();//vyčištění text boxů
                NameBox.Clear();
                PriceBox.Clear();
                if(p.Create())//pokud selže vložení do db, nepřidá se ani do listu
                    Products.Add(p);//Přdání do listu
                    source1.DataSource = PDAO.GetAllKategori();//aktualizace seznamu kategorie
                    Kategories.DataSource = source1;
                dataGridView.Refresh();
                source.ResetBindings(false);//Aktualizování tabulky

            }
            catch (Exception)
            {
                MessageBox.Show("Error while adding product! Price and weight must be positive numeber.", "Error", buttonok, iconerror);
            }

        }

        /// <summary>
        /// funkce umoznuje updatovat kategorii, bud se vezme nova kategorie nebo z listu kategorii
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditKategori_Click(object sender, EventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;//nalezení řádku pro zmazání
            if (dataGridView.SelectedCells[0].Value == null)//kontola zda zvolený řádek má nějaké hodnoty
                return;
            foreach (Product p in Products)
            {
                if ((int)dataGridView.Rows[row].Cells[0].Value == p.ID)//nalezení objektu pro zmazání
                {
                    if (checkBox.Checked && NewKategori.Text != "")//Kontrola zda uživatel chce novou kategorii nebo z menu, aby se vzalá nová kategorie, text box nesmí být prázdný a checkbox musí být true
                        p.Kategori = NewKategori.Text;
                    else
                        p.Kategori = Kategories.SelectedItem.ToString();
                    p.Updatekategori();//Update v DB
                    dataGridView.Refresh();//aktualize hlavni tabulky
                    source1.DataSource = PDAO.GetAllKategori();//aktualizece seznamu kategorii
                    Kategories.DataSource = source1;
                }
            }
        }

        /// <summary>
        /// Aktualizace tabulky
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Products = PDAO.GetAllProducts();
            source.DataSource = Products;
            dataGridView.DataSource = source;
            dataGridView.Refresh();
        }
    }
}
