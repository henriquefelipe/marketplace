using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Domain
{
    public class payment
    {
        public string type { get; set; }
        public string method { get; set; }
        public string provider { get; set; }
        public string flag { get; set; }
        public string nsu { get; set; }
        public decimal value { get; set; }
    }
}
