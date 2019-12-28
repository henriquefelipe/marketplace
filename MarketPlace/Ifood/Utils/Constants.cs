using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Utils
{
    public static class Constants
    {
        public const string URL_BASE = "https://pos-api.ifood.com.br/";       
        public const string VERSION_1 = "v1.0";
        public const string VERSION_2 = "v2.0";
        public const string VERSION_3 = "v3.0";

        public const string URL_TOKEN = "oauth/token";
        public const string URL_EVENT_POOLING = "events%3Apolling";
        public const string URL_EVENT_ACNOWLEDGMENT = "events/acknowledgment";
        public const string URL_ORDER = "orders";
        public const string URL_ORDER_INTEGRATION = "statuses/integration";
        public const string URL_ORDER_CONFIRMATION = "statuses/confirmation";
        public const string URL_ORDER_DISPATCH = "statuses/dispatch";
        public const string URL_ORDER_REJECTION = "statuses/rejection";
        public const string URL_ORDER_CANCELATION = "statuses/cancellationRequested";
        public const string URL_ORDER_CANCELATION_ACCEPTED = "statuses/consumerCancellationAccepted";
        public const string URL_ORDER_CANCELATION_DENIED = "statuses/consumerCancellationDenied";
        public const string URL_ORDER_READY_TO_DELIVER = "statuses/readyToDeliver";
    }
}
