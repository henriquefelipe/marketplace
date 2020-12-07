using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Domain
{
    public class item
    {
        public string sku { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string comments { get; set; }
        public decimal unit_price_with_discount { get; set; }
        public decimal unit_price_without_discount { get; set; }
        public decimal percentage_discount { get; set; }
        public decimal quantity { get; set; }
        public List<subitem> subitems { get; set; }
    }
}
