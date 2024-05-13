using System;
using System.Collections.Generic;
using System.Text;

namespace Plug4Sales.Domain
{
    public class delivery
    {
        public string deliveredBy { get; set; }
        public string estimatedDeliveryDateTime { get; set; }
        public string deliveryDateTime { get; set; }
        public deliveryAddress deliveryAddress { get; set; }
    }

    public class deliveryAddress
    {
        public deliveryAddress()
        {
            country = "BR";
        }

        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string reference { get; set; }
        public string formattedAddress { get; set; }
        public string postalCode { get; set; }
        public coordinates coordinates { get; set; }
    }

    public class coordinates
    {
         public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
