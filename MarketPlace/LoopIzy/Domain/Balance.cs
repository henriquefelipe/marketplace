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
    }

    public class Transaction
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
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
