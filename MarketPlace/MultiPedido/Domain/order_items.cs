using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Domain
{
    public class order_items
    {
        public decimal id { get; set; }
        public decimal? menu_item_id { get; set; }
        public string menu_name { get; set; }
        public decimal? menu_price { get; set; }
        public decimal? cuisine_id { get; set; }
        public decimal quantity { get; set; }
        public string type { get; set; }
        public string notes { get; set; }
        public string external_id { get; set; }
        public crust crust { get; set; }
        //public dough dough { get; set; }
        public List<flavors> flavors { get; set; }
        public List<order_extras> extras { get; set; }
        public string pizza_price_behavior { get; set; }
        public decimal? pizza_price { get; set; }
        public int? number_of_flavors { get; set; }
        public decimal? item_sub_total { get; set; }
        public string ncm { get; set; }
        public string restaurant_id { get; set; }
        public bool is_weight_product { get; set; }
    }
}
