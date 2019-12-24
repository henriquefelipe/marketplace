using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class customer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string taxPayerIdentificationNumber { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
