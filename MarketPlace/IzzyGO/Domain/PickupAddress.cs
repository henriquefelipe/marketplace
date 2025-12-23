using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class PickupAddress
    {
        public string FormattedAddress { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Complement { get; set; }
        public Coordinates Coordinates { get; set; } = new Coordinates();
    }
}
