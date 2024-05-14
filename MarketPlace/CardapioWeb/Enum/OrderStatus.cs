using System;
using System.Collections.Generic;
using System.Text;

namespace CardapioWeb.Enum
{
    public class OrderStatus
    {
        public const string CANCELED = "canceled";
        public const string CONFIRMED = "confirmed";
        public const string WAITING_CONFIRMATION = "waiting_confirmation";
        public const string PENDIND_PAYMENT = "pending_payment";
        public const string PENDING_ONLINE_PAYMENT = "pending_online_payment";
        public const string SCHEDULED_CONFIRMED = "scheduled_confirmed";
        public const string READY = "ready";
        public const string RELEASED = "released";
        public const string WAITING_TO_CATCH = "waiting_to_catch";
        public const string DELIVERED = "delivered";
        public const string CANCELING = "canceling";
        public const string CLOSED = "closed";        
    }
}
