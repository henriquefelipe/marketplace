using System;
using System.Collections.Generic;
using System.Text;

namespace PixCommerce.Domain
{
    public class order
    {
        public order()
        {
            items = new List<item>();
        }

        public string orderType { get; set; }
        public string salesChannel { get; set; }
        public string orderTiming { get; set; }
        public string createdAt { get; set; }
        public string id { get; set; }
        public string displayId { get; set; }
        public string preparationStartDateTime { get; set; }
        public string extraInfo { get; set; }
        public order_delivery delivery { get; set; }
        public order_merchant merchant { get; set; }
        public order_total total { get; set; }
        public order_customer customer { get; set; }    
        public order_payments payments { get; set; }
        public List<item> items { get; set; }
    }

    public class order_merchant
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class order_total
    {
        public decimal benefits { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal orderAmount { get; set; }
        public decimal subTotal { get; set; }
        public decimal additionalFees { get; set; }
    }
}
