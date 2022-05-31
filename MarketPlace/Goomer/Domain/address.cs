using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Domain
{
    public class address
    {
        public string zipCode { get; set; }
        public string street { get; set; }
        public string streetNumber { get; set; }
        public string complement { get; set; }
        public string neighborhood { get; set; }
        public string reference { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
}
