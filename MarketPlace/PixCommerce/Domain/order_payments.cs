using System;
using System.Collections.Generic;
using System.Text;

namespace PixCommerce.Domain
{
    public class order_payments
    {
        public order_payments()
        {

        }

        public int pending { get; set; }
        public int prepaid { get; set; }
        public List<order_payments_methods> methods { get; set; }
    }

    public class order_payments_methods
    {
        //"wallet": {},
        public string method { get; set; }
        public bool prepaid { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public decimal value { get; set; }
        //"cash": {},
        //"card": {}
    }
}
