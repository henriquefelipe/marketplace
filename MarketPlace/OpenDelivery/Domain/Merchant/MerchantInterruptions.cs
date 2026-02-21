using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain.Merchant
{
    public class MerchantInterruptions
    {
        public string id { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; } 
    }
}
