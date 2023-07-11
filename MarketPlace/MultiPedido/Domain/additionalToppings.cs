using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Domain
{
    public class additionalToppings
    {
        public int? id {  get; set; }
        public string name { get; set; }
        public decimal? price { get; set; }
        public decimal? available { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int? restaurant_id { get; set; }
        public int? toppings_category_id { get; set; }
        public string external_id { get; set; }
        public decimal? cashier_id { get; set; }
    }
}
