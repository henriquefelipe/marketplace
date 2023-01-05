using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class otherFees
    {
        public string name { get; set; }
        public string type { get; set; }
        public string receivedBy { get; set; }
        public string receiverDocument { get; set; }
        public price price { get; set; }
        public string observation { get; set;}
    }
}
