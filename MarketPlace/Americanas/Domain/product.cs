using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Americanas.Domain
{
    public class product
    {
        public product()
        {
            inputs = new List<input>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int weight { get; set; }
        public string sku { get; set; }
        public string ean { get; set; }
        public int is_promotion { get; set; }
        public object promotion_price { get; set; }
        public int price { get; set; }
        public string note { get; set; }
        public string created_at { get; set; }
        public List<input> inputs { get; set; }
    }
}
