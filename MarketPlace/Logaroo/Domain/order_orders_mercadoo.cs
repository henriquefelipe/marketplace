using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Domain
{
    public class order_orders_mercadoo
    {
        public order_orders_data_mercadoo data { get; set; }
    }

    public class order_orders_data_mercadoo
    {
        public order_orders_data_mercadoo()
        {
            items = new List<order_orders_item_mercadoo>();
        }

        public int id { get; set; }
        public order_orders_address_mercadoo address { get; set; }
        public int bag_id { get; set; }
        public string created_at { get; set; }
        public order_orders_customer_mercadoo customer { get; set; }
        public string cpf { get; set; }
        public string code { get; set; }
        public string delivery_type { get; set; }
        public List<order_orders_item_mercadoo> items { get; set; }
        public order_orders_payment_mercadoo payment { get; set; }
        public order_orders_price_mercadoo price { get; set; }
        public bool? status { get; set; }
        public order_orders_store_mercadoo store { get; set; }
        public order_orders_sales_channel_mercadoo sales_channel { get; set; }
        public order_orders_destiny destiny { get; set; }
    }
}
