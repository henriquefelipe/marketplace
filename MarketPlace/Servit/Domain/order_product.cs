using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class order_product
    {
        public order_product()
        {
            order_options = new List<order_product_option>();
        }

        public int id { get; set; }
        public int product_id { get; set; }
        public string sku { get; set; } // utilizado no cancelamento
        public int order_id { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public decimal? discount { get; set; }
        public string note { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public product product { get; set; }
        public List<order_product_option> order_options { get; set; }
    }

    public class product
    {
        public int id { get; set; }
        public string sku { get; set; } // utilizado na criação do pedido
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public decimal price { get; set; }
        public product_session session { get; set; }
    }

    public class product_session
    {
        public string name { get; set; }
    }

    public class order_product_option
    {
        public int id { get; set; }
        public int order_product_id { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public string item_name { get; set; }
        public string option_name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string sku { get; set; }
        public option option { get; set; }
    }

    public class option
    {
        public int id { get; set; }
        public int external_code { get; set; }
    }
}
