using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
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

    public class coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
