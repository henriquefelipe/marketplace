using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipedi.Domain
{
    public class order
    {
        public order()
        {
            items = new List<item>();
            benefits = new List<benefits>();
        }

        public string _id { get; set; }
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
        public string deliveryDateTime { get; set; }
        public string preparationStartDateTime { get; set; }
        public int preparationTimeInSeconds { get; set; }
        public bool scheduled { get; set; }
        public List<benefits> benefits { get; set; }
        public string observation { get; set; }
    }
}
