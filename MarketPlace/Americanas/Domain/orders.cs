using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Americanas.Domain
{
    public class orders
    {
        public int id { get; set; }
        public int amount { get; set; }
        public int store_id { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string payment_method { get; set; }
        public string delivery_method { get; set; }
        public string created_at { get; set; }
    }
}
