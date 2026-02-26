using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoopIzy.Domain
{
    public class CustomerRequest
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; } // For Patch
    }

    public class CustomerResponse
    {
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("customers")]
        public List<Customer> Customers { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("points_balance")]
        public int PointsBalance { get; set; }
    }
}
