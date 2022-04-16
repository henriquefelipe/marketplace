using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class result
    {
        public int pagina { get; set; }
        public int totalRegistros { get; set; }
        public bool erro { get; set; }
        public string mensagemErro { get; set; }
        public List<resposta> resposta { get; set; }
    }
}
