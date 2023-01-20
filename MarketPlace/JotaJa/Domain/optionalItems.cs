using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Domain
{
    public class optionalItems
    {
        public decimal? quantity { get; set; }
        public string optionalCategory { get; set; }
        public string optionalItemName { get; set; }
        public decimal? price { get; set; }
        public string sku { get; set; }
        public string billingType { get; set; }
    }
}
