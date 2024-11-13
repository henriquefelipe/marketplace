using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Domain
{
    public class customer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string origin { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string neighborhood { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public coordinates coordinates { get; set; }
    }

    public class DeliveryAddress
    {
        public string formattedAddress { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string postalCode { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string reference { get; set; }
        public string complement { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public coordinates coordinates { get; set; }
    }

    public class coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
