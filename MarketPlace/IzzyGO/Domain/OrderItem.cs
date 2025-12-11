using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class OrderItem
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Unit { get; set; }
        public string ExternalCode { get; set; }
    }
}
