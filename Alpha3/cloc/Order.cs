using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha3
{
    class Order
    {
        private int id;
        private DateTime dateOfEstablishment;
        private DateTime dateOfExpiration;
        private DateTime dateOfPickUp;
        private bool payWithCash;
        private int customer_id;
        private int store_id;
        private double entirePrice;

        private Customer customer;
        private Store s;

        public List<int> orderedProductsID = new List<int>();
        public List<Product> orderedProducts = new List<Product>();

        public int ID
        {
            get
            {
                return id;
            }
        }
        public int Store_id
        {
            get
            {
                return store_id;
            }
            set
            {
                store_id = value;
            }
        }
        public int Customer_id
        {
            get
            {
                return customer_id;
            }
            set
            {
                customer_id = value;
            }
        }
        public DateTime DateOfEstablishment
        {
            set
            {
                dateOfEstablishment = value;
            }
            get
            {
                return dateOfEstablishment;
            }
        }
        public DateTime DateOfExpiration
        {
            set
            {
                dateOfExpiration = value;
            }
            get
            {
                return dateOfExpiration;
            }
        }
        public DateTime DateOfPickUp
        {
            set
            {
                dateOfPickUp = value;
            }
            get
            {
                return dateOfPickUp;
            }
        }
        public bool PayWithCash
        {
            get
            {
                return payWithCash;
            }
            set
            {
                payWithCash = value;
            }
        }
        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
            }
        }
        public Store PickUpPoint
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }
        public double EntirePrice
        {
            set
            {
                entirePrice = value;
            }
            get
            {
                return entirePrice;
            }
        }

        public Order(int id)
        {
            this.id = id;
        }
        public Order() { }

        public void addToProductsID(int id)
        {
            this.orderedProductsID.Add(id);
        }
        public void addToProducts(Product p)
        {
            this.orderedProducts.Add(p);
        }
    }
}
