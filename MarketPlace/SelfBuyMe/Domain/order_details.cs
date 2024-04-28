using System;
using System.Collections.Generic;
using System.Text;

namespace SelfBuyMe.Domain
{
    public class order_details
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
        public decimal total_price { get; set; }
        public decimal subtotal { get; set; }
        public decimal discount { get; set; }
        public order_details_product product { get; set; }

    }

    public class order_details_product
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public string barcode { get; set; }
        public order_details_product_category category { get; set; }
    }

    public class order_details_product_category
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool is_alcoholic { get; set; }
    }
}
