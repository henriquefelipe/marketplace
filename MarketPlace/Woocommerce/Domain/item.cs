using System;
using System.Collections.Generic;
using System.Text;

namespace Woocommerce.Domain
{
    public class item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int product_id { get; set; }
        public int variation_id { get; set; }
        public int quantity { get; set; }
        public string tax_class { get; set; }
        public string subtotal { get; set; }
        public string subtotal_tax { get; set; }
        public string total { get; set; }
        public string total_tax { get; set; }
        public string sku { get; set; }
        public decimal price { get; set; }
    }
}
