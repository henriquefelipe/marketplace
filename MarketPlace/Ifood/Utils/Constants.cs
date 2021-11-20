using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Utils
{
    public static class Constants
    {
        public const string URL_BASE = "https://merchant-api.ifood.com.br/";
        public const string VERSION_1 = "v1.0";
        public const string VERSION_2 = "v2.0";
        public const string VERSION_3 = "v3.0";

        public const string URL_TOKEN = "authentication/v1.0/oauth/token";
        public const string URL_EVENT_POOLING = "events%3Apolling";
        public const string URL_EVENT_POOLING_2 = "events:polling";
        public const string URL_EVENT_ACNOWLEDGMENT = "events/acknowledgment";
        public const string URL_ORDER = "orders";
        public const string URL_ORDER_INTEGRATION = "statuses/integration";
        public const string URL_ORDER_CONFIRM = "confirm";
        public const string URL_ORDER_START_PREPARATION = "startPreparation";
        public const string URL_ORDER_DISPATCH = "dispatch";
        public const string URL_ORDER_REJECTION = "rejection";
        public const string URL_ORDER_CANCELATION = "requestCancellation";
        public const string URL_ORDER_CANCELATION_ACCEPTED = "acceptedCancelation";
        public const string URL_ORDER_CANCELATION_DENIED = "denyCancellation";
        public const string URL_ORDER_READY_TO_PICKUP = "readyToPickup";
    }
}
