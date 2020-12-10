using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_valor_troco
    {
        public bool status { get; set; }
        public decimal recebido { get; set; }
        public decimal valor { get; set; }
    }
}
