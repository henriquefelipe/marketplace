using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Enum
{
    public class OrderStatus
    {
        public const string CREATED = "CREATED";
        public const string APPROVED = "APPROVED";
        public const string DONE = "DONE";
        public const string SENT = "SENT";
        public const string OVER = "OVER";
        public const string CANCELED = "CANCELED";
        public const string SCHEDULED = "SCHEDULED";
    }
}
