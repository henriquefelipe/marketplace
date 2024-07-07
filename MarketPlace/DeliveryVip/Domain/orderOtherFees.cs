using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class orderOtherFees
    {
        public string name { get; set; }
        public string type { get; set; }
        public string receivedBy { get; set; }
        public string receiverDocument { get; set; }
        public price price { get; set; }
    }
}
