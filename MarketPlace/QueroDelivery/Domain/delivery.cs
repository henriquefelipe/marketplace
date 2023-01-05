using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class delivery
    {
        public string deliveredBy { get; set; }
        public deliveryAddress deliveryAddress { get; set; }
        public string estimatedDeliveryDateTime { get; set; }
        public string deliveryDateTime { get; set; }
    }
}
