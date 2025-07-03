using System;
using System.Collections.Generic;
using System.Text;

namespace FoodyDelivery.Enum
{
    public static class OrderStatus
    {
        public const string OPEN = "open"; // Pedido pendente
        public const string CLOSED = "closed"; // Pedido aceito
        public const string DISPATCHED = "dispatched"; //Pedido despachado (atribuído) para entregadores
        public const string ACCEPTED = "accepted"; //Pedido aceito pelo entregador
        public const string ON_GOING = "onGoing";  // Pedido a caminho da entrega
        public const string DELIVERED = "delivered"; // Pedido entregue
        public const string READY = "ready"; // Pedido pronto para ser despachado
        public const string CANCELLED = "cancelled"; // Pedido cancelado
        public const string REJECTED = "rejected";  // Pedido rejeitado
    }
}
