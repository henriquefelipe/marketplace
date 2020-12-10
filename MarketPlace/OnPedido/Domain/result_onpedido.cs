using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class result_onpedido
    {
        public result_onpedido_status status { get; set; }
        public result_onpedido_pedido pedido { get; set; }
    }

    public class result_onpedido_pedido
    {
        public pedido pedido { get; set; }
    }
}
