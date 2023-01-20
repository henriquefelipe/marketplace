using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Domain
{
    public class orderProducts
    {
        public decimal? quantity { get; set; }
        public string note { get; set; }
        public decimal? productId { get; set; }
        public decimal? price { get; set; }
        public string productName { get; set; }
        public string sku { get; set; }
        public string unity { get; set; }
        public bool fraction { get; set; }
        public decimal? fractionlPrice { get; set; }
        public List<optionalItems> optionalItems { get; set; }
    }
}
