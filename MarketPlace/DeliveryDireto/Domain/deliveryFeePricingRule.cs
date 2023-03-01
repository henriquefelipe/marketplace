using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class deliveryFeePricingRule
    {
        public string type { get; set; }
        public price fixedPrice { get; set; }
        public string dynamicPriceStart { get; set; }
        public string dynamicPriceEnd { get; set; }
        public string dynamicPrice { get; set; }
        public string freeDeliveryMinimumOrder { get; set; }
        public string freeDeliveryTimeout { get; set; }
    }
}
