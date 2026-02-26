using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoopIzy.Domain
{
    public class VoucherResponse
    {
        [JsonProperty("vouchers")]
        public List<Voucher> Vouchers { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class Voucher
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } // 'active', 'redeemed', 'expired'

        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonProperty("reward_name")]
        public string RewardName { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("is_valid")]
        public bool? IsValid { get; set; }
    }

    public class VoucherActionRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; } // 'validate' or 'redeem'

        [JsonProperty("attendant_pin")]
        public string AttendantPin { get; set; }
    }

    public class VoucherActionResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("voucher_id")]
        public string VoucherId { get; set; }

        [JsonProperty("attendant_name")]
        public string AttendantName { get; set; }

        [JsonProperty("redeemed_at")]
        public string RedeemedAt { get; set; }

        // From Validate
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }

        [JsonProperty("reward_name")]
        public string RewardName { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
    }
}
