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
    public class Product
    {
        private int id;
        private string name;
        private float price;
        private int weight;
        private string kategori;

        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons button = MessageBoxButtons.OK;

        public int ID
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Cena nesmí být záporná!");
                }
                else
                {
                    price = value;
                }
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Váha nesmí být záporná!");
                }
                else
                {
                    weight = value;
                }
            }
        }
        public string Kategori
        {
            get
            {
                return kategori;
            }
            set
            {
                kategori = value;
            }
        }
        public Product(int id) 
        {
            this.id = id;
        }
        public Product()
        {

        }
        /// <summary>
        /// Produkt který si tuto metodu zavolá se vloží do databáze
        /// </summary>
        /// <returns>Poklud vše proběhne OK vratí se true</returns>
        public bool Create()
        {
            try
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                int kategori = 0;
                using (MySqlCommand command = new MySqlCommand("select * from kategorie where nazev = @nazev", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@nazev", this.kategori));
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        kategori = Convert.ToInt32(reader[0]);
                    }
                    reader.Close();
                }
                if(kategori == 0)
                {
                    using (MySqlCommand command = new MySqlCommand("insert into kategorie(nazev) values(@nazev);", conn))
                    {
                        command.Parameters.Add(new MySqlParameter("@nazev", this.kategori));
                        command.ExecuteNonQuery();
                        command.CommandText = "Select @@Identity";
                        kategori = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                using (MySqlCommand command = new MySqlCommand("insert into produkt(nazev, cena, vaha, kategorie_id) values(@nazev, @price, @weight, @kategorie_id); ", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@nazev", this.name));
                    command.Parameters.Add(new MySqlParameter("@price", this.price));
                    command.Parameters.Add(new MySqlParameter("@weight", this.weight));
                    command.Parameters.Add(new MySqlParameter("@kategorie_id", kategori));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while creating " + this.GetType().ToString().Replace("Alpha3.", "") + "!", "Error", button, icon);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Update nazvu
        /// </summary>
        public void Updatename()
        {
            try
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("update Produkt set nazev = @nazev where id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@nazev", this.name));
                    command.Parameters.Add(new MySqlParameter("@id", this.id));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while creating " + this.GetType().ToString().Replace("Alpha3.", "") + "!", "Error", button, icon);
            }
        }
        /// <summary>
        /// Update váhy
        /// </summary>
        public void Updateweight()
        {
            try
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("update Produkt set vaha = @weight where id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@weight", this.Weight));
                    command.Parameters.Add(new MySqlParameter("@id", this.id));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while creating " + this.GetType().ToString().Replace("Alpha3.", "") + "!", "Error", button, icon);
            }
        }
        /// <summary>
        /// Update ceny
        /// </summary>
        public void Updateprice()
        {
            try
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("update Produkt set cena = @price where id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@price", this.price));
                    command.Parameters.Add(new MySqlParameter("@id", this.id));
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while creating " + this.GetType().ToString().Replace("Alpha3.", "") + "!", "Error", button, icon);
            }
        }
        public void Updatekategori()
        {
            //try
            //{
                int kategori = 0;
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("select * from kategorie where nazev = @nazev", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@nazev", this.kategori));
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        kategori = Convert.ToInt32(reader[0]);
                    }
                    reader.Close();
                }
                if (kategori == 0)
                {
                    using (MySqlCommand command = new MySqlCommand("insert into kategorie(nazev) values(@nazev);", conn))
                    {
                        command.Parameters.Add(new MySqlParameter("@nazev", this.kategori));
                        command.ExecuteNonQuery();
                        command.CommandText = "Select @@Identity";
                        kategori = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                using (MySqlCommand command = new MySqlCommand("update Produkt set kategorie_id = @kategorie_id where id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@kategorie_id", kategori));
                    command.Parameters.Add(new MySqlParameter("@id", this.id));
                    command.ExecuteNonQuery();
                }
            //}
            //catch (MySqlException)
            //{
            //    MessageBox.Show("Error while updating " + this.GetType().ToString().Replace("Alpha3.", "") + "!", "Error", button, icon);
            //}
        }
        /// <summary>
        /// Z DB se smaže Produkt který si tuto metodu zavolá
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            try
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("delete from Produkt where id = @id;", conn))
                {
                    command.Parameters.Add(new MySqlParameter("@id", this.id));
                    command.ExecuteNonQuery();                    
                }                
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error while deleting Produkt! The Produkt is referenced in another table! Cannot be deleted!", "Error", button, icon);
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return name + ", price " + price;
        }
    }
}
