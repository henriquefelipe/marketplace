using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class totals
    {
        public price deliveryFee { get; set; }
        public price discount { get; set; }
        public price requiredChange { get; set; }
        public price serviceFee { get; set; }
        public price subtotal { get; set; }
        public price total { get; set; }
    }
}
