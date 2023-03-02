using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class deliveryArea
    {
        public decimal? id { get; set; }
        public string type { get; set; }
        public center center { get; set; }
        public decimal? radius { get; set; }
        public deliveryFeePricingRule deliveryFeePricingRule { get; set; }
        public decimal? minimumWaitingMinutes { get; set; }
        public decimal? maximumWaitingMinutes { get; set; }
        public inactivationPeriod inactivationPeriod { get; set; }
        public bool? isActive { get; set; }
        public string name { get; set; }
    }
}
