
using System.ComponentModel;

namespace OnPedido.Enum
{
    public enum OrderStatus
    {
        [Description("")]
        Nenhum = 0,
        [Description("RECEBIDO")]
        Recebido = 1,
        [Description("CONFIRMADO")]
        Confirmado = 2,
        [Description("DESPACHADO")]
        Despachado = 3,
        [Description("ENTREGUE")]
        Entregue = 4,
        [Description("CANCELADO")]
        Cancelado = 5,
        [Description("AVALIADO")]
        Avaliado = 6
    }
}
