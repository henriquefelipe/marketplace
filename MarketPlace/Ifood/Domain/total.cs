using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class total
    {
        public double subTotal { get; set; }
        public double deliveryFee { get; set; }
        public int benefits { get; set; }
        public double orderAmount { get; set; }
        public double additionalFees { get; set; }
    }
}
