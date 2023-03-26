using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha3
{
    class ProductDAO
    {
        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        /// <summary>
        /// Vytáhne data z tabulky produkt
        /// </summary>
        /// <returns>List s objekty typu Product</returns>
        public List<Product> GetAllProducts()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            List<Product> Products = new List<Product>();
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from Produkt inner join kategorie on kategorie.id = produkt.kategorie_id;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product(Convert.ToInt32(reader[0]));
                        p.Name = reader[1].ToString();
                        p.Price = float.Parse(reader[2].ToString());
                        p.Weight = Convert.ToInt32(reader[3]);
                        p.Kategori = reader[7].ToString();
                        Products.Add(p);
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting products info!", "Error", button, icon);
            }
            return Products;
        }
        /// <summary>
        /// vytáhne jeden konkrétní Produkt
        /// </summary>
        /// <param name="id">ID pobočky která se má vrátit</param>
        /// <returns>objekt typu Product s příslušným ID</returns>
        public Product GetProductsByID(int id)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            Product p = null;
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from Produkt inner join kategorie on kategorie.id = produkt.kategorie_id where produkt.id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", id));
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Product(Convert.ToInt32(reader[0]));
                        p.Name = reader[1].ToString();
                        p.Price = float.Parse(reader[2].ToString());
                        p.Weight = Convert.ToInt32(reader[3]);
                        p.Kategori = reader[7].ToString();
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting products info!", "Error", button, icon);
            }
            return p;
        }
        /// <summary>
        /// Dostane seznam kategorii z db
        /// </summary>
        /// <returns>List stringů s nazvy kategorii</returns>
        public List<string> GetAllKategori()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            List<string> Kategories = new List<string>();
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from Kategorie", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Kategories.Add(reader[1].ToString());
                    }
                    reader.Close();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting kategories info!", "Error", button, icon);
            }
            return Kategories;
        }
    }
}
