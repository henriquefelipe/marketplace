using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class eventPooling
    {
        public string eventId {  get; set; }
        public string createdAt { get; set; }
        public string merchantId { get; set; }
        public string eventType { get; set; }
        public string orderId { get; set; }
        public string orderUrl { get; set; }
        public string orderType { get; set; }
    }
}
