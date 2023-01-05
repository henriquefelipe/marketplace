using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class customer
    {
        public string id { get; set; }
        public phone phone { get; set; }
        public string documentNumber { get; set; }
        public string name { get; set; }
        public decimal ordersCountOnMerchant { get; set; }
    }

    public class phone
    {
        public string number { get; set; }
        public string extension { get; set; }
    }
}
