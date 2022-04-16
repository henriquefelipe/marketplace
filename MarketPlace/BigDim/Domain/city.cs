using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class city
    {
        public int id { get; set; }
        public state state { get; set; }
        public string name { get; set; }
        public string dateExclusion { get; set; }
        public string codigoIbge { get; set; }
    }
}
