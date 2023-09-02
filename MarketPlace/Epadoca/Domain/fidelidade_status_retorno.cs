using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Domain
{
    public class fidelidade_status_retorno
    {
        public fidelidade_status_retorno()
        {
            premioL = new List<fidelidade_status_retorno_premioL> { };
        }

        public int pontos { get; set; }
        public bool isAtivo { get; set; }

        public List<fidelidade_status_retorno_premioL> premioL { get; set; }
    }

    public class fidelidade_status_retorno_premioL
    {
        public string guid { get; set; }
        public string nome { get; set; }
        public int quantidadePonto { get; set; }
        public string regra { get; set; }
        public decimal valor { get; set; }
    }
}
