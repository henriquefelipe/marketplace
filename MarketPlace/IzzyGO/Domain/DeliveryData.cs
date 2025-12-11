using IzzyGO.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace IzzyGO.Domain
{
    public class DeliveryData
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("deliveryId")]
        public string Id { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("distance")]
        public double? Distance { get; set; }

        [JsonProperty("fee")]
        public decimal? Fee { get; set; }

        [JsonProperty("estimatedTime")]
        public int? EstimatedTime { get; set; }

        [JsonProperty("autoAccepted")]
        public bool AutoAccepted { get; set; }

        [JsonProperty("createdat")]
        public object CreatedAt { get; set; }
    }
}
