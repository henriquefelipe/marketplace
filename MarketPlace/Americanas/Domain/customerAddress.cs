using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Americanas.Domain
{
    public class customerAddress
    {
        public string street { get; set; }
        public string number { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public object state { get; set; }
        public string country { get; set; }
        public string zip_code { get; set; }
        public string complement { get; set; }
    }
}
