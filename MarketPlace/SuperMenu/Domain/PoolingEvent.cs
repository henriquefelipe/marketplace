using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu.Domain
{
    public class poolingEvent
    {
        public string id { get; set; }
        public string code { get; set; }
        public string correlationId { get; set; }
        public bool integrated { get; set; }
        public DateTime createdAt { get; set; }
        
    }

    public static class PoolingEventStatusCode
    {
        public const string PENDING_APPROVAL = "PENDING_APPROVAL";         //Significa que o pedido foi feito pelo cliente e foi 'colocado' no sistema;
        public const string APPROVED = "APPROVED"; //Significa que o pedido foi confirmado e aceito pelo estabelecimento;
        public const string WAITING_FOR_DELIVERY = "WAITING_FOR_DELIVERY";   //Esse status é exclusivo para quem está com sua integração com o motoboy.com ativada. Ela indica que o motoboy foi solicitado e que o mesmo está para chegar para fazer a entrega;
        public const string OUT_FOR_DELIVERY = "OUT_FOR_DELIVERY";   // Significa que o pedido já foi mandado para entrega;
        public const string CANCELLATION_REQUEST_FAILED = "CANCELLATION_REQUEST_FAILED ";   //em caso de falha no cancelamento.
        public const string DELIVERED = "DELIVERED"; //Significa que o pedido foi entregue com sucesso;
        public const string REFUSED = "REFUSED";   //Significa que o pedido foi rejeitado pelo estabelecimento (lembrando que isso não apaga o pedido);
        public const string CANCELLED = "CANCELLED";   //Significa que o pedido foi cancelado;
    }
}
