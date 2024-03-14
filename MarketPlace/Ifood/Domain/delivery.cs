using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class delivery
    {
        public string mode { get; set; }
        public string deliveredBy { get; set; }
        public string deliveryDateTime { get; set; }
        public string pickupCode { get; set; }
        public string observations { get; set; }
        public deliveryAddress deliveryAddress { get; set; }
    }
}
