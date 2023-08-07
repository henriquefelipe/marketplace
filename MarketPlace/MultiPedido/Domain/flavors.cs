using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Domain
{
    public class flavors
    {
        public int? id {  get; set; }
        public int? menu_item_id { get; set; }
        public string name { get; set; }
        public decimal? price { get; set; }
        public string notes { get; set; }
        public decimal? quantity { get; set; }
        public string external_id { get; set; }
        public List<additionalToppings> additionalToppings { get; set; }
        public int? restaurant_id { get; set; }
    }
}
