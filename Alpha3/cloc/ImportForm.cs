using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Alpha3
{
    public partial class ImportForm : Form
    {
        ProductDAO PDAO = new ProductDAO();
        List<Product> Products = new List<Product>();

        BindingSource source = new BindingSource();
        public ImportForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Nacte xml soubor s produkty
        /// </summary>
        /// <returns>List s objekty</returns>
        private List<Product> nacist()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings["FileToImport"];
            XmlSerializer seril = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("List"));
            using (StreamReader sw = new StreamReader(new FileStream(result, FileMode.Open))) 
            { 
                return (List<Product>)seril.Deserialize(sw);
            }            
        }
        /// <summary>
        /// Uploadne list do DB, smazani dat z tabulky
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (Products.Count < 0)//Pokud v tabulce nic neni, return
                return;
            foreach (Product p in Products)
            {
                p.Create();
            }
            source.DataSource = null;
            dataGridView.DataSource = source;//smazani dat z tabulky
        }
        /// <summary>
        /// Ukaze data v tabulce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                Products = nacist();
                source.DataSource = Products;
                dataGridView.DataSource = source;
            }
            catch (Exception)
            {
                MessageBox.Show("Chyba během načítání!");              
            }
        }
    }
}
