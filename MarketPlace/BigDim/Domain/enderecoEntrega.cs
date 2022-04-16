using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class enderecoEntrega
    {
        public int id { get; set; }
        public city city { get; set; }
        public string street { get; set; }
        public string complement { get; set; }
        public string number { get; set; }
        public string neighborhoord { get; set; }
        public string cep { get; set; }
        public object reference { get; set; }
    }
}
