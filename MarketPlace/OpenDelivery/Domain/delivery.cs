using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class delivery
    {        
        public string deliveredBy { get; set; }
        public deliveryAddress deliveryAddress { get; set; }
        public string deliveryDateTime { get; set; }
        public string pickupCode { get; set; }
        public string estimatedDeliveryDateTime { get; set; }
        
    }
}
