using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipedi.Domain
{
    public class merchant
    {
        public string id { get; set; }
        public string nome { get; set; }
        public List<string> phones { get; set; }
        public address address { get; set; }        
    }
}
