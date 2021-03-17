using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipedi.Enum
{
    public enum OrderStatus
    {
        Pendente = 0,
        Confirmado = 1,
        PedidoEmProducao = 2,
        PedidoPronto = 3,
        SaiuParaEntrega = 4,
        Entregue = 5,
        Cancelado = 6
    }
}
