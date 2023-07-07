using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Domain
{
    public class order_extras
    {
        public decimal? id { get; set; }
        public decimal? menu_item_id { get; set; }
        public decimal? quantity { get; set; }
        public string extra_name { get; set; }
        public decimal? extra_price { get; set; }
        public decimal? external_id { get; set; }
        public string ncm { get; set; }
        public decimal? invoice_price { get; set; }
        public string restaurant_id { get; set; }
    }
}
