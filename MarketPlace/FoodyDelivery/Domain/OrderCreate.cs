using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodyDelivery.Domain
{
    public class OrderCreate
    {
        [JsonIgnore]
        public string uid { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public decimal deliveryFee { get; set; }
        public string paymentMethod { get; set; }
        public string notes { get; set; }

        [JsonIgnore]
        public decimal courierFee { get; set; }
        public decimal orderTotal { get; set; }
        public string orderDetails { get; set; }
        public OrderCreatedeliveryPoint deliveryPoint { get; set; }

        public OrderCreateCustomer customer { get; set; }
        public string date { get; set; }
    }
}
