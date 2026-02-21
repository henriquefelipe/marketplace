using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class eventAcknowledgment
    {
        public string id { get; set; }
        public string orderId { get; set; }
        public string eventType { get; set; }
    }
}
