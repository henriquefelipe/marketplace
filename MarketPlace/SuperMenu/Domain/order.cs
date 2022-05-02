using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu.Domain
{
    public class order
    {
        public order()
        {
            items = new List<item>();
        }

        public string id { get; set; }       
        public string createdAt { get; set; }
        public string type { get; set; }
        public merchant merchant { get; set; }
        public payment payment { get; set; }
        public customer customer { get; set; }
        public List<item> items { get; set; }
        public decimal subTotal { get; set; }
        public decimal totalPrice { get; set; }
        public decimal deliveryFee { get; set; }
        public string changeFor { get; set; }
        public deliveryAddress deliveryAddress { get; set; }     
        
        public discount discount { get; set; }
        public coupon coupon { get; set; }
    }
}
