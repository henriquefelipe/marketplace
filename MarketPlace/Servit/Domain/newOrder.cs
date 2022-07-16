using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class newOrder
    {
        public newOrder()
        {
            products = new List<newOrder_product>();
        }

        public string table_number { get; set; }
        public string note { get; set; }
        public int price { get; set; }

        public List<newOrder_product> products { get; set; }
    }

    public class newOrder_product
    {
        public newOrder_product()
        {
            options = new List<newOrder_product_option>();
        }

        public string name { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public List<newOrder_product_option> options { get; set; }
    }

    public class newOrder_product_option
    {
        public string item_name { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string sku { get; set; }
    }
}
