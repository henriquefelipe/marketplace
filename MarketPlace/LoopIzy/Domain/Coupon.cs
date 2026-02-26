using Newtonsoft.Json;

namespace LoopIzy.Domain
{
    public class CouponResponse
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("coupon")]
        public Coupon Coupon { get; set; }

        [JsonProperty("total_uses")]
        public int? TotalUses { get; set; }

        [JsonProperty("max_uses")]
        public int? MaxUses { get; set; }

        // From Redeem/Validate POST
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("redemption_id")]
        public string RedemptionId { get; set; }

        [JsonProperty("discount_applied")]
        public decimal? DiscountApplied { get; set; }
    }

    public class Coupon
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        [JsonProperty("discount_value")]
        public decimal DiscountValue { get; set; }

        [JsonProperty("min_order_value")]
        public decimal? MinOrderValue { get; set; }

        [JsonProperty("max_discount_amount")]
        public decimal? MaxDiscountAmount { get; set; }

        [JsonProperty("starts_at")]
        public string StartsAt { get; set; }

        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class CouponActionRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; } // 'validate' or 'redeem'

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("order_total")]
        public decimal? OrderTotal { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("validated_by")]
        public string ValidatedBy { get; set; }
    }
}
