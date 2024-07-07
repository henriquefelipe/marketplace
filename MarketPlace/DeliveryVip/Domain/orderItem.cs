using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class orderItem
    {
        public orderItem()
        {
            options = new List<orderItem>();
        }

        public string id { get; set; }
        public int index { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int quantity { get; set; }
        public price unitPrice { get; set; }
        public price optionsPrice { get; set; }
        public price totalPrice { get; set; }
        public List<orderItem> options { get; set; }
    }
}
