using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class UpdateDeliveryStatusResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("deliveryId")]
        public string DeliveryId { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("previousStatus")]
        public string PreviousStatus { get; set; }

        [JsonProperty("newStatus")]
        public string NewStatus { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
