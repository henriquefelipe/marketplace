using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class orderitem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string instructions { get; set; }
        public string type { get; set; }
        public int type_id { get; set; }
        public int parent_id { get; set; }
        public decimal total_item_price { get; set; }       
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal item_discount { get; set; }
        public decimal cart_discount { get; set; }
        public decimal cart_discount_rate { get; set; }
        public List<item> options { get; set; }
        public string coupon { get; set; }
    }
}
