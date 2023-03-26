using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha3
{
    class StoreDAO
    {
        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        ProductDAO PDAO = new ProductDAO();
        /// <summary>
        /// Vytáhne data z tabulky Pobocka
        /// </summary>
        /// <returns>List s objekty typu Store</returns>
        public List<Store> GetAllStores()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            List<Store> Stores = new List<Store>();
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from Pobocka inner join mesto on mesto.id = pobocka.mesto_id;", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Store s = new Store(Convert.ToInt32(reader[0]));
                        s.Street = reader[1].ToString();
                        s.House_number = Convert.ToInt32(reader[2]);
                        s.Mesto = reader[6].ToString();
                        Stores.Add(s);                        
                    }
                    reader.Close();
                }
                using (MySqlCommand command = new MySqlCommand("select * from uskladneno", conn))
                {                    
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foreach (Store s in Stores)
                        {
                            if (s.ID == Convert.ToInt32(reader[2]))
                            {
                                s.AddItem(new StoredItems(Convert.ToInt32(reader[1]), Convert.ToInt32(reader[3])));
                            }
                        }
                    }
                    reader.Close();
                }
                foreach (Store s in Stores)
                {
                    foreach (StoredItems item in s.WarHouse)
                    {
                        item.Product = PDAO.GetProductsByID(item.Product_id);
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting stores info!", "Error", button, icon);
            }
            return Stores;
        }
        /// <summary>
        /// vrátí data jedné pobočky 
        /// </summary>
        /// <param name="id">ID pobočky která se má vrátit</param>
        /// <returns>objekt typu Store s příslušným ID</returns>
        public Store GetStoreByID(int id)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            Store s = null;
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from Pobocka inner join mesto on mesto.id = pobocka.mesto_id where pobocka.id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", id));
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        s = new Store(Convert.ToInt32(reader[0]));
                        s.Street = reader[1].ToString();
                        s.House_number = Convert.ToInt32(reader[2]);
                        s.Mesto = reader[6].ToString();
                    }
                    reader.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error while getting products info!", "Error", button, icon);
            }
            return s;
        }        
    }
}
