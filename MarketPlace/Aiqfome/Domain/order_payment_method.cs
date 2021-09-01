using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order_payment_method
    {
        public string name { get; set; }
        public string subtotal { get; set; }
        public string delivery_tax { get; set; }
        public string total { get; set; }
        public decimal change { get; set; }
        public string coupon_value { get; set; }
        public bool pre_paid { get; set; }

    }
}
