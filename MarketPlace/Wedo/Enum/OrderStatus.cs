using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Enum
{
    public class OrderStatus
    {
        public const string CANCELLED = "CANCELLED";
        public const string PENDING_APPROVAL = "PENDING_APPROVAL";
        public const string APPROVED = "APPROVED";
        public const string READY_FOR_TAKEAWAY = "READY_FOR_TAKEAWAY";
        public const string OUT_FOR_DELIVERY = "OUT_FOR_DELIVERY";
        public const string DELIVERED = "DELIVERED";
        public const string FINISHED = "FINISHED";
        public const string REFUNDED = "REFUNDED";
    }
}
