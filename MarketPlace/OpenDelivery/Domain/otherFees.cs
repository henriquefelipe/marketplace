using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDelivery.Domain
{
    public class otherFees
    {
        public string name { get; set; }
        public string type { get; set; }
        public string receivedBy { get; set; }
        public string receiverDocument { get; set; }

        public value_currency price { get; set; }
        public string observation { get; set; }
    }
}
