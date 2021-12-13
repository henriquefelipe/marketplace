using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class payment
    {
        public bool online { get; set; }
        public string name { get; set; }
        public string cod { get; set; }
        public string externalVendorCode { get; set; }
        public bool pix { get; set; }
        public string tid { get; set; }
        public string card { get; set; }
        public string type { get; set; }
    }
}
