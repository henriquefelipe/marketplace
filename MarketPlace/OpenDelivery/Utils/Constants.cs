using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Utils
{
    public static class Constants
    {        
        public const string URL_TOKEN = "oauth/token";        
        public const string URL_EVENT_POOLING = "v1/events:polling";
        public const string URL_EVENT_ACNOWLEDGMENT = "v1/events/acknowledgment";
        public const string URL_ORDER = "v1/orders";
        public const string URL_ORDER_INTEGRATION = "statuses/integration";
        public const string URL_ORDER_CONFIRM = "confirm";
        public const string URL_ORDER_PREPARING = "preparing";
        public const string URL_ORDER_READY_TO_PICKUP = "readyToPickup";
        public const string URL_ORDER_DISPATCH = "dispatch";
        public const string URL_ORDER_REJECTION = "rejection";
        public const string URL_ORDER_CANCELATION = "requestCancellation";
        public const string URL_ORDER_CANCELATION_ACCEPTED = "acceptedCancelation";
        public const string URL_ORDER_CANCELATION_DENIED = "denyCancellation";
                
    }
}
