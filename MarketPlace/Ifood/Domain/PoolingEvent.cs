using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class poolingEvent
    {
        public string code { get; set; }

        public string correlationId { get; set; }
        public DateTime createdAt { get; set; }
        public string id { get; set; }

        #region "ifood 2"
        public string fullCode { get; set; }

        public string orderId { get; set; }
        #endregion
    }

    public static class PoolingEventStatusCode
    {
        public const string PLACED = "PLACED";         //Indica um pedido foi colocado no sistema.
        public const string INTEGRATED = "INTEGRATED"; //Indica um pedido que foi recebido pelo e-PDV.
        public const string CONFIRMED = "CONFIRMED";   //Indica um pedido confirmado.
        public const string CANCELLED = "CANCELLED";   //Indica um pedido que foi cancelado.
        public const string CANCELLATION_REQUEST_FAILED = "CANCELLATION_REQUEST_FAILED ";   //em caso de falha no cancelamento.
        public const string DISPATCHED = "DISPATCHED"; //Indica um pedido que foi despachado ao cliente.
        public const string DELIVERED = "DELIVERED";   //Indica um pedido que foi entregue.
        public const string CONCLUDED = "CONCLUDED";   //Indica um pedido que foi concluído (Em até duas horas do fluxo normal)*.
    }

    public static class PoolingEventStatusCode_VERSAO_2
    {
        public const string PLACED = "PLC";

    }
}
