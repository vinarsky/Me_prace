using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha3
{
    class Store //store acts as warhouse and as pickup point for orders
    {
        private int id;
        private string street;
        private int house_number;
        private string mesto;
        public List<StoredItems> WarHouse = new List<StoredItems>();

        public int ID
        {
            get
            {
                return id;
            }
        }
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }
        public int House_number
        {
            get
            {
                return house_number;
            }
            set
            {
                house_number = value;
            }
        }
        public string Mesto
        {
            get
            {
                return mesto;
            }
            set
            {
                mesto = value;
            }
        }
        public void AddItem(StoredItems p)
        {
            WarHouse.Add(p);
        }
        public Store(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return Street + " " + House_number + ", " + Mesto;
        }
    }
}
