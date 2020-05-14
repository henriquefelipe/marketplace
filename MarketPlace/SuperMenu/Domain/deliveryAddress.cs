using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu.Domain
{
    public class deliveryAddress
    {
        public string formattedAddress { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public coordinates coordinates { get; set; }
        public string neighborhood { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string postalCode { get; set; }
        public string reference { get; set; }
        public string complement { get; set; }
    }

    public class coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
