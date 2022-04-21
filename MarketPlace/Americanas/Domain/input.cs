using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Americanas.Domain
{
    public class input
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
    }
}
