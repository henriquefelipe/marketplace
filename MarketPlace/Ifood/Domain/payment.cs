using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class payment
    {
        public string name { get; set; }
        public string code { get; set; }
        public decimal value { get; set; }
        public bool prepaid { get; set; }
        public string issuer { get; set; }
    }
}
