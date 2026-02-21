using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class total
    {
        public value_currency itemsPrice { get; set; }
        public value_currency otherFees { get; set; }
        public value_currency discount { get; set; }
        public value_currency orderAmount { get; set; }
        //public decimal additionalFees { get; set; }
    }
}
