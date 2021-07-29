using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class currency
    {
        public decimal amount { get; set; }
        public string currency_code { get; set; }
        public string formatted_amount { get; set; }
    }
}
