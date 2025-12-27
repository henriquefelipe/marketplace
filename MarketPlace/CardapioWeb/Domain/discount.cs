using System;
using System.Collections.Generic;
using System.Text;

namespace CardapioWeb.Domain
{
    public class discount
    {
        public string kind {  get; set; }
        public string category { get; set; }
        public decimal total { get; set; }
        public int? total_points { get; set; }
        public int? coupon_id { get; set; }
        public string coupon_name { get; set; }
        public int? item_id { get; set; }
        public string item_name { get; set; }        
    }
}
