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
        public int id { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public order_data_items_owner_mercadoo owner { get; set; }
        public order_data_items_details_mercadoo details { get; set; }
    }

    public class order_data_items_owner_mercadoo
    {
        public string cpf { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class order_data_items_details_mercadoo
    {
        public order_data_items_details_mercadoo()
        {
            payments = new List<order_data_items_details_payments_mercadoo>();
        }

        public string birth { get; set; }
        public string created_at { get; set; }
        public string delivery_forecast { get; set; }
        public string delivery_method { get; set; }
        public int? destiny { get; set; }
        public List<order_data_items_details_payments_mercadoo> payments { get; set; }
    }

    public class order_data_items_details_payments_mercadoo
    {
        public string type { get; set; }
        public string value { get; set; }       
    }
}
