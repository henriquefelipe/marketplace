using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Enum
{
    public static class DeliveryStatus
    {
        public const string Pending = "PENDING";
        public const string Preparing = "PREPARING";
        public const string Ready = "READY_FOR_PICKUP";
        public const string Assigned = "ASSIGNED";
        public const string InTransit = "IN_TRANSIT";
        public const string Delivered = "DELIVERED";
        public const string Cancelled = "CANCELLED";
    }
}
