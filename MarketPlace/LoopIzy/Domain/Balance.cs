using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoopIzy.Domain
{
    public class BalanceResponse
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("points_balance")]
        public int PointsBalance { get; set; }

        [JsonProperty("cashback")]
        public CashbackData Cashback { get; set; }

        [JsonProperty("cashback_potencial")]
        public decimal? CashbackPotencial { get; set; }

        [JsonProperty("for_order")]
        public ForOrderData ForOrder { get; set; }

        [JsonProperty("blackout")]
        public BlackoutData Blackout { get; set; }

        [JsonProperty("recent_transactions")]
        public List<Transaction> RecentTransactions { get; set; }
    }

    public class CashbackData
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("eligible")]
        public bool Eligible { get; set; }

        [JsonProperty("min_points")]
        public int MinPoints { get; set; }

        [JsonProperty("points_per_currency")]
        public int PointsPerCurrency { get; set; }

        [JsonProperty("possible_credit_value")]
        public decimal PossibleCreditValue { get; set; }

        [JsonProperty("pending_credit_value")]
        public decimal? PendingCreditValue { get; set; }

        [JsonProperty("cashback_potencial")]
        public decimal? CashbackPotencial { get; set; }

        [JsonProperty("blackout")]
        public bool? Blackout { get; set; }

        [JsonProperty("for_order")]
        public ForOrderData ForOrder { get; set; }
    }

    public class ForOrderData
    {
        [JsonProperty("order_total")]
        public decimal? OrderTotal { get; set; }

        [JsonProperty("allowed")]
        public bool? Allowed { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("multiplier")]
        public decimal? Multiplier { get; set; }

        [JsonProperty("max_credit_value_by_rule")]
        public decimal? MaxCreditValueByRule { get; set; }

        [JsonProperty("usable_credit_value")]
        public decimal? UsableCreditValue { get; set; }

        [JsonProperty("points_to_use")]
        public int? PointsToUse { get; set; }

        [JsonProperty("remaining_to_pay")]
        public decimal? RemainingToPay { get; set; }
    }

    public class BlackoutData
    {
        [JsonProperty("points")]
        public bool? Points { get; set; }

        [JsonProperty("cashback")]
        public bool? Cashback { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reference_type")]
        public string ReferenceType { get; set; }

        [JsonProperty("store_id")]
        public string StoreId { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }

    public class BalanceAdjustmentRequest
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } // 'credit' or 'debit'

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class BalanceAdjustmentResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("new_balance")]
        public decimal NewBalance { get; set; }
    }
}
