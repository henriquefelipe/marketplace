using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Enum
{
    public class EventTypes
    {
        public const string CREATED = "CREATED";
        public const string CONFIRMED = "CONFIRMED";
        public const string DISPATCHED = "DISPATCHED";
        public const string READY_FOR_PICKUP = "READY_FOR_PICKUP";
        public const string PICKUP_AREA_ASSIGNED = "PICKUP_AREA_ASSIGNED";
        public const string CONCLUDED = "CONCLUDED";
        public const string CANCELLED = "CANCELLED";
        public const string CANCELLATION_REQUESTED = "CANCELLATION_REQUESTED";
        public const string CANCELLATION_REQUEST_DENIED = "CANCELLATION_REQUEST_DENIED";
        public const string ORDER_CANCELLATION_REQUEST = "ORDER_CANCELLATION_REQUEST";
    }
}
