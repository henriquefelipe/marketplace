using Newtonsoft.Json;

namespace LoopIzy.Domain
{
    public class RedeemRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; } // 'redeem', 'reverse', 'list'

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("reward_id")]
        public string RewardId { get; set; }

        [JsonProperty("attendant_pin")]
        public string AttendantPin { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }

    public class RedeemResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("redemption_id")]
        public string RedemptionId { get; set; }

        [JsonProperty("reversed_redemption_id")]
        public string ReversedRedemptionId { get; set; }

        [JsonProperty("reward_name")]
        public string RewardName { get; set; }

        [JsonProperty("points_spent")]
        public int? PointsSpent { get; set; }

        [JsonProperty("points_returned")]
        public int? PointsReturned { get; set; }

        [JsonProperty("new_balance")]
        public int NewBalance { get; set; }

        [JsonProperty("attendant_name")]
        public string AttendantName { get; set; }
    }
}
