using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class order
    {
        public string id { get; set; }
        public string reference { get; set; }
        public string shortReference { get; set; }
        public string createdAt { get; set; }
        public string type { get; set; }
        public merchant merchant { get; set; }
        public List<payment> payments { get; set; }
        public customer customer { get; set; }
        public List<item> items { get; set; }
        public decimal subTotal { get; set; }
        public decimal totalPrice { get; set; }
        public decimal deliveryFee { get; set; }
        public deliveryAddress deliveryAddress { get; set; }
        public DateTime deliveryDateTime { get; set; }
        public int preparationTimeInSeconds { get; set; }
    }
}
