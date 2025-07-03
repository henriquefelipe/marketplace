using System;
using System.Collections.Generic;
using System.Text;

namespace FoodyDelivery.Domain
{
    public class OrderCreateResult : OrderCreate
    {
        public string uid { get; set; }
        public decimal courierFee { get; set; }
        public string orderTrackerUrl { get; set; }
        public string despatchMode { get; set; }
        public string readyDate { get; set; }
        public string despatchDate { get; set; }
        public string collectedDate { get; set; }
        public string deliveryDate { get; set; }
        public string creationDate { get; set; }
        public string updateDate { get; set; }
        public OrderCreateCourierResult courier { get; set; }
    }

    public class OrderCreateCourierResult
    {
        public string courierPhone { get; set; }
        public string courierName { get; set; }
        public string courierType { get; set; }
    }
}
