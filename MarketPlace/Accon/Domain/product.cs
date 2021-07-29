using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class product
    {
        public product()
        {
            modifiers = new List<product>();
        }

        public string id { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public string notes { get; set; }
        public decimal total { get; set; }
        public string externalVendorCode { get; set; }
        public List<product> modifiers { get; set; }
        public price price { get; set; }
        public bool higherPrice { get; set; }
        public string group { get; set; }
    }
}
