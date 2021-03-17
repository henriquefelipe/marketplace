using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipedi.Domain
{
    public class address
    {
        public string formattedAddress { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string postalCode { get; set; }

    }
}
