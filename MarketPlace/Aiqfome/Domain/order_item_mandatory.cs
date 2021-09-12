using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order_item_mandatory
    {
        public string group { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
        public string sku { get; set; }
    }
}
