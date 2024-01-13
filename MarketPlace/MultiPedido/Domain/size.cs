using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Domain
{

    public class size
    {
        public List<flavors> flavors { get; set; }
        public int pizza_price { get; set; }
        public int menu_item_id { get; set; }
        public int quantity { get; set; }
        public string notes { get; set; }
        public int number_of_flavors { get; set; }
        public string restaurant_id { get; set; }
        public string pizza_price_behavior { get; set; }
        public object cuisine_id { get; set; }
        public List<order_extras> extras { get; set; }
        public string external_id { get; set; }
        public string type { get; set; }
        public crust crust { get; set; }
        public decimal menu_price { get; set; }
        public decimal item_sub_total { get; set; }
        public bool is_combo { get; set; }
        public string menu_name { get; set; }
        public string ncm { get; set; }
        public int id { get; set; }
        public List<dough> dough { get; set; }
    }

}
