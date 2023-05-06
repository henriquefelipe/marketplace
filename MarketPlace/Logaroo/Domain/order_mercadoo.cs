using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Domain
{
    public class order_mercadoo
    {
        public order_data_mercadoo data { get; set; }        
    }

    public class order_data_mercadoo
    {
        public order_data_mercadoo()
        {
            items = new List<order_data_items_mercadoo>();
        }

        public int current_page { get; set; }
        public List<order_data_items_mercadoo> items { get; set; }
        public int per_page { get; set; }
        public int totals { get; set; }
    }

    public class order_data_items_mercadoo
    {
        public order_data_items_mercadoo()
        {
            orders = new List<order_orders_mercadoo>();
        }

        public string status { get; set; }
        public List<order_orders_mercadoo> orders { get; set; }
    }
}
