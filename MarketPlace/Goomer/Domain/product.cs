using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Domain
{
    public class product
    {
        public product()
        {
            observations = new List<string>();
        }

        public string name { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public string code { get; set; }
        public decimal quantity { get; set; }
        public List<string> observations { get; set; }
        public List<extra> extras { get; set; }
    }
}
