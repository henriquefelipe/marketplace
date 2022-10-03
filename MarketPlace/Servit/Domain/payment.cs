using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class payment
    {
        public int id { get; set; }
        public string type { get; set; }
        public decimal value { get; set; }
    }
}
