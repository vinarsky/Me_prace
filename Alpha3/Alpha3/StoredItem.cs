using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha3
{
    /// <summary>
    /// Třída StoredItem je pouze produkt s počtem na skladě. Aby výpis skladu neměl několi stejných produktů za sebou tak je to tato třída která má vlastnot Amount
    /// </summary>
    class StoredItems
    {
        private int amount;
        private Product p;
        private int product_id;

        public Product Product
        {
            get
            {
                return p;
            }
            set
            {
                p = value;
            }
        }
        public int Product_id
        {
            get
            {
                return product_id;
            }
            set
            {
                product_id = value;
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
        public StoredItems(int p_id, int amount)
        {
            this.Product_id = p_id;
            this.Amount = amount;
        }
    }
}
