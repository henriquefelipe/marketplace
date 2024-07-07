using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class order
    {
        public string id {  get; set; }
        public string type { get; set; }
        public string displayId { get; set; }
        public string createdAt { get; set; }
        public string orderTiming { get; set; }
        public string preparationStartDateTime { get; set; }
        public string lastEvent { get; set; }
        public bool sendDelivered { get; set; }
        public bool sendTracking { get; set; }
        public orderMerchant merchant { get; set; }
        public List<orderItem> items { get; set; }    
        public List<orderOtherFees> otherFees { get; set; }
        public orderTotal total { get; set; }
        public orderPayments payments { get; set; }
        public orderCustomer customer { get; set; }
        public orderDelivery delivery { get; set; }

    }
}
