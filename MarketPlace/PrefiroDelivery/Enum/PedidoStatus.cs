using System;
using System.Collections.Generic;
using System.Text;

namespace PrefiroDelivery.Enum
{
    public enum PedidoStatus
    {
        Solicitado = 1,
        EmProducao = 2,
        SaiuParaEntregaOuProntoParaRetirada = 3,
        Entregue = 4,
        Cancelado = 5,
        SaiuParaEntrega = 6
    }
}
