using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Domain
{
    public class order_orders_item_mercadoo
    {
        public order_orders_item_mercadoo()
        {
            subitems = new List<order_orders_item_subitem_mercadoo>();
        }

        public int id { get; set; }
        public string code_pdv { get; set; }
        public string obs { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public bool is_offer { get; set; }
        public decimal price_offer { get; set; }
        public decimal total_price { get; set; }
        public List<order_orders_item_subitem_mercadoo> subitems { get; set; }
    }

    public class order_orders_item_subitem_mercadoo
    {
        public int id { get; set; }
        public string code_pdv { get; set; }       
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
    }
}
