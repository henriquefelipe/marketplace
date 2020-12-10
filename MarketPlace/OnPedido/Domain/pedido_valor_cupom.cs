using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_valor_cupom
    {
        public bool status { get; set; }
        public decimal desconto { get; set; }
        public string cupom { get; set; }
    }
}
