using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Utils
{
    public static class Constants
    {
        public const string URL_BASE = "https://backend.apiservit.com/";
        
        public const string URL_TOKEN = "pdv/oauth/token";
        public const string URL_MERCHANTS = "pdv/merchants";        
        public const string URL_EVENTS_MERCHANT = "pdv/events/merchant";
        public const string URL_EVENT_MECHANT = "pdv/event/mechant";
        public const string URL_EVENTS_ACKNOWLEDGMENT = "pdv/events/acknowledgment";

        public const string URL_ORDERS = "pdv/event/orders";
        public const string URL_TABLE_CHANGE = "change/table";
    }
}
