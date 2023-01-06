using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Utils
{
    public static class Constants
    {
        public const string URL_BASE = "https://stageapi.quero.io/";

        public const string URL_EVENT_POOLING = "events:polling";
        public const string URL_ORDER = "orders";
        public const string URL_ORDER_CONFIRM = "confirm";
        public const string URL_ORDER_REJECTION = "request-cancellation";
        public const string URL_ORDER_DISPATCH = "dispatch";
        public const string URL_ORDER_READY_TO_PICKUP = "ready-fo-pickup";
        public const string URL_ORDER_COMPLETED = "delivery-completed";
    }
}
