using IzzyGO.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IzzyGO.Domain
{
    public class DeliveryData
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("deliveryId")]
        public string Id { get; set; }

        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("distance")]
        public double? Distance { get; set; }

        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }

        [JsonPropertyName("estimatedTime")]
        public int? EstimatedTime { get; set; }

        [JsonPropertyName("autoAccepted")]
        public bool AutoAccepted { get; set; }
        public object CreatedAt { get; set; }
    }
}
