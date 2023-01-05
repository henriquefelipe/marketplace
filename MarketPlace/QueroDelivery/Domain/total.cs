using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class total
    {
        public price itemsPrice { get; set; }
        public price otherFees { get; set; }
        public price discount { get; set; }
        public price orderAmount { get; set; }
    }
}
