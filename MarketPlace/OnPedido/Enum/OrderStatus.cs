using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Enum
{
    public enum OrderStatus
    {
        PedidoNaoRecebido  = 0,
        PedidoRecebido = 1,
        PedidoConfirmado = 2,
        PedidoDespachado = 3,
        PedidoEntregue = 4,
        PedidoCancelado = 5
    }
}
