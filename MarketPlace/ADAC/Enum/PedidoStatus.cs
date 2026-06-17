using System;
using System.Collections.Generic;
using System.Text;

namespace ADAC.Enum
{
    public static class PedidoStatus
    {
        public const string PENDING = "pending";
        public const string IN_PREPARATION = "IN_PREPARATION"; //pedido entrou em produção
        public const string OUT_FOR_DELIVERY = "OUT_FOR_DELIVERY"; // saiu para entrega
        public const string READY_FOR_PICKUP = "READY_FOR_PICKUP"; // pronto para retirada
        public const string CANCELLED = "CANCELLED"; // pedido cancelado
    }
}
