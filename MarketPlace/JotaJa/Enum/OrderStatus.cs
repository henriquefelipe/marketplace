using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Enum
{
    public class OrderStatus
    {
        public const string NEW_ORDER = "NEW_ORDER"; //A Aceitar
        public const string CONFIRMED = "CONFIRMED"; // Em Produção
        public const string PICKED_UP = "PICKED_UP"; // Saiu para Entrega
        public const string CANCELED = "CANCELED"; // Deletado
        public const string FULFILLED = "FULFILLED"; // Finalizado
        public const string PENDING = "PENDING"; // Pagamento Pendente
        public const string PREPARED = "PREPARED"; // Preparado (Para retirada)
    }
}
