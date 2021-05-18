using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class issuer
    {
        public string cnpj { get; set; }
        public string ie { get; set; }
        public string name { get; set; }
        public string tradingName { get; set; }
        public address address { get; set; }
    }
}
