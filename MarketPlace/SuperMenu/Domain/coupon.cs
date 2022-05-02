using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu.Domain
{
    public class coupon
    {
        public bool doNotApplyToOffers { get; set; }
        public coupon_discountType discountType { get; set; }
    }

    public class coupon_discountType
    {
        public decimal value { get; set; }
        public int type { get; set; }
    }
}
