using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class client_address_parts
    {
        public string street { get; set; }
        public string bloc { get; set; }
        public string floor { get; set; }
        public string apartment { get; set; }
        public string intercom { get; set; }
        public string more_address { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string full_address { get; set; }
    }
}
