using System;

namespace OpenDelivery.Domain.Merchant
{
    public class Merchant
    {
        public string id { get; set; }
        public string name { get; set; }
        public string corporateName { get; set; }
        public string description { get; set; }
        public int averageTicket { get; set; }
        public bool exclusive { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public MerchantAddress address { get; set; }
        public MerchantOperations operations { get; set; }
    }

    public class MerchantAddress
    {
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string district { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
    }

    public class MerchantOperations
    {
        public string name { get; set; }
        public MerchantSalesChannel salesChannel { get; set; }
    }

    public class MerchantSalesChannel
    {
        public string name { get; set; }
        public string enabled { get; set; }
    }
}
