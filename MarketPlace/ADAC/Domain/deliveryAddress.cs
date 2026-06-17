using System;
using System.Collections.Generic;
using System.Text;

namespace ADAC.Domain
{
    public class deliveryAddress
    {
        public string street { get; set; }
        public string number { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string complement { get; set; }
        public string reference { get; set; }
        public string formatted { get; set; }
    }
}
