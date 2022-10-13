using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Domain
{
    public class compra
    {
        public compra()
        {
            items = new List<item>();
            discounts = new List<discount>();
        }

        public string registration { get; set; }
        public List<item> items { get; set; }
        public payment payment { get; set; }
        public List<discount> discounts { get; set; }
    }

    public class item
    {
        public string category { get; set; }
        public string subcategory { get; set; }
        public string product_name { get; set; }
        public string code { get; set; }
        public string unit_type { get; set; }
        public decimal unit_value { get; set; }
        public decimal quantity { get; set; }
        public decimal total_value { get; set; }
    }

    public class payment
    {
        public string coupon { get; set; }
        public decimal total { get; set; }
        public int method { get; set; }
        public int installments { get; set; }
        public int splits { get; set; }
        public string date { get; set; }
    }

    public class discount
    {
        public string code { get; set; }
        public decimal quantity { get; set; }
    }
}
