using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class order
    {
        public order()
        {
            order_products = new List<order_product>();
        }

        public int id { get; set; }
        public decimal price { get; set; }
        public int status_id { get; set; }
        public string note { get; set; }
        public string created_at { get; set; }
        public string accepted_at { get; set; }
        public string updated_at { get; set; }
        public int bill_id { get; set; }
        public int restaurant_id { get; set; }
        public int waiter_id { get; set; }
        public string accepted_by { get; set; }
        public string accepted_auto { get; set; }
        public bool? created_by_waiter { get; set; }       

        public bill bill { get; set; }
        public List<order_product> order_products { get; set; }
    }
}
