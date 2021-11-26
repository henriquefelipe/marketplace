using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class total
    {
        public decimal subTotal { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal benefits { get; set; }
        public decimal orderAmount { get; set; }
        public decimal additionalFees { get; set; }
    }
}
