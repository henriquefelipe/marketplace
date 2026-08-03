using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class ResponseOrderBill
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }
        [JsonProperty("items")]
        public List<OrderItem> Items { get; set; }
    }
}
