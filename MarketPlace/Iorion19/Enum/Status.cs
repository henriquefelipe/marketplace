using System;
using System.Collections.Generic;
using System.Text;

namespace Iorion19.Enum
{
    public enum Status
    {
        PedidoCancelado = 0,
        PedidoPendente = 1,
        PedidoEmProducao = 2,
        PedidoEmTransitoOuProntoParaRetirada = 3,
        PeditoEntregueOuRetirado = 4,
        PedidoAceito_EmCasoDeAgendamento = 5
    }
}
