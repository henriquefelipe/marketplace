using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Domain
{
    public class order_orders_address_mercadoo
    {
        public int id { get; set; }
        public string city { get; set; }
        public string type { get; set; }
        public string state { get; set; }
        public string title { get; set; }
        public string number { get; set; }
        public string street { get; set; }
        //public bool default { get; set; }
        public string zipcode { get; set; }
        public string landmark { get; set; }
        public order_orders_address_location_mercadoo location { get; set; }
        public string subtitle { get; set; }
        public string complement { get; set; }
        public string neighborhood { get; set; }
    }

    public class order_orders_address_location_mercadoo
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
