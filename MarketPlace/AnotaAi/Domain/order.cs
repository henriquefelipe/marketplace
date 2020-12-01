using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Domain
{
    public class order
    {
        public string _id { get; set; }
        public string id { get; set; }
        public int check { get; set; }
        public int shortReference { get; set; }
        public string createdAt { get; set; }
        public string type { get; set; }
        public string time_max { get; set; }
        public order_merchant merchant { get; set; }
        public List<order_payments> payments { get; set; }
        public order_customer customer { get; set; }
        public List<item> items { get; set; }
        public decimal total { get; set; }
        public decimal deliveryFee { get; set; } // taxa de entrega
        public List<order_discounts> discounts { get; set; }
    }
}
