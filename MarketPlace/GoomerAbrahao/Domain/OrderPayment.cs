using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class OrderPayment
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("flag")]
        public string Flag { get; set; }
        [JsonProperty("remote_id")]
        public string RemoteId { get; set; }
        [JsonProperty("provider")]
        public string Provider { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}
