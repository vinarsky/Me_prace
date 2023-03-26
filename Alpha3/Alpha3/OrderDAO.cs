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
    class OrderDAO
    {
        //objekty se používají u vyskakovacích okének, když se něco nepovede, nebo uživatel musí něco potvrdit
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        CustomerDAO CDAO = new CustomerDAO();
        ProductDAO PDAO = new ProductDAO();
        StoreDAO SDAO = new StoreDAO();

        /// <summary>
        /// Vytáhne data o všech objednávkách se seznamem s produků
        /// </summary>
        /// <returns>List s objednávkách</returns>
        public List<Order> GetAllOrders()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            List<Order> Orders = new List<Order>();
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * from objednavka", conn))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Order o = new Order(Convert.ToInt32(reader[0]));
                        o.DateOfEstablishment = Convert.ToDateTime(reader[1]);
                        o.DateOfExpiration = Convert.ToDateTime(reader[2]);
                        if(!(reader.IsDBNull(3)))
                            o.DateOfPickUp = Convert.ToDateTime(reader[3]);
                        if (reader[4].ToString() == "1")
                            o.PayWithCash = true;
                        else
                            o.PayWithCash = false;
                        o.EntirePrice = Convert.ToDouble(reader[7]);
                        o.Customer_id = Convert.ToInt32(reader[6]);
                        o.Store_id = Convert.ToInt32(reader[5]);
                        Orders.Add(o);
                    }
                    reader.Close();
                }
                foreach (Order o in Orders)
                {
                    o.Customer = CDAO.GetCustomerByID(o.Customer_id);
                }
                foreach (Order o in Orders)
                {
                    o.PickUpPoint = SDAO.GetStoreByID(o.Store_id);
                }
                using (MySqlCommand command = new MySqlCommand("select * from objednane_produkty", conn))
                {
                    List<int> IDs = new List<int>();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foreach(Order o in Orders)
                        {
                            if(o.ID == Convert.ToInt32(reader[2]))
                            {
                                o.addToProductsID(Convert.ToInt32(reader[1]));
                            }
                        }
                    }
                    reader.Close();
                }
                foreach (Order o in Orders)
                {
                    foreach (int i in o.orderedProductsID)
                    {
                        o.addToProducts(PDAO.GetProductsByID(i));
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while getting orders info!", "Error", button, icon);
            }
            return Orders;

        }
    }
}
