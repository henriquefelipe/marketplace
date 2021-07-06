using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class externalVendors
    {
        public string name { get; set; }
        public bool failed { get; set; }
        public bool finished { get; set; }
        public status status { get; set; }
    }
}
