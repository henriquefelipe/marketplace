using System;
using System.Collections.Generic;
using System.Text;

namespace Repediu.Domain
{
    public class customer
    {
        public string id {  get; set; }
        public string name { get; set; }
        public int ordersCountOnMerchant { get; set; }
        public string documentNumber { get; set; }
        public customer_phone phone { get; set; }
    }

    public class customer_phone
    {
        public string number { get; set; }
        public string extension { get; set; }
    }
}
