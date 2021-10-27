using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class additionalFees
    {
        public decimal total { get; set; }
        public additionalFees_values values { get; set; }
    }

    public class additionalFees_values
    {
        public string type { get; set; }
        public decimal value { get; set; }
    }
}
