using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class deliveryAddress
    {
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
}