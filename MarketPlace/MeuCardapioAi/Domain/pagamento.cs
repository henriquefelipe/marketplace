using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class pagamento
    {
        public int id { get; set; }
        public string formaDePagamento { get; set; }
        public decimal trocoPara { get; set; }
        public bool levarTroco { get; set; }
        public decimal valor { get; set; }
        public decimal valorTroco { get; set; }
    }
}
