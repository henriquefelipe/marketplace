using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Domain
{
    public class product
    {
        public string code { get; set; }
        public decimal unit_value { get; set; }
        public decimal quantity { get; set; }
        public decimal discount_value { get; set; }
        public decimal discount_item { get; set; }
    }
}
