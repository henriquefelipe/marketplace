using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class orderPayments
    {
        public decimal prepaid { get; set; }
        public decimal pending { get; set; }
        public List<orderPaymentsMethods> methods { get; set; }
    }

    public class orderPaymentsMethods
    {
        public decimal value { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string method { get; set; }
        public string methodInfo { get; set; }
    }
}
