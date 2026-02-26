using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoopIzy.Domain
{
    public class CashbackResponse
    {
        [JsonProperty("credits")]
        public List<CashbackCredit> Credits { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("points_spent")]
        public int? PointsSpent { get; set; }

        [JsonProperty("credit_value")]
        public decimal? CreditValue { get; set; }

        [JsonProperty("new_balance")]
        public int? NewBalance { get; set; }

        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonProperty("used_at")]
        public string UsedAt { get; set; }
    }

    public class CashbackCredit
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("points_spent")]
        public int PointsSpent { get; set; }

        [JsonProperty("credit_value")]
        public decimal CreditValue { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }
    }

    public class CashbackActionRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; } // 'generate' or 'use'

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; } // for generate

        [JsonProperty("points")]
        public int? Points { get; set; } // for generate

        [JsonProperty("value")]
        public decimal? Value { get; set; } // for generate

        [JsonProperty("code")]
        public string Code { get; set; } // for use
    }
}
