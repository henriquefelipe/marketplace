using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class OrderPaymentRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("waiter")]
        public string Waiter { get; set; }

        [JsonProperty("table_position")]
        public int TablePosition { get; set; }

        [JsonProperty("customer")]
        public OrderCustomer Customer { get; set; }

        [JsonProperty("payment")]
        public OrderPayment Payment { get; set; }
    }
}
