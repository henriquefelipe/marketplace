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

        [JsonProperty("points_balance")]
        public int PointsBalance { get; set; }

        [JsonProperty("recent_transactions")]
        public List<Transaction> RecentTransactions { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

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
        public int Amount { get; set; }

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
        public int Amount { get; set; }

        [JsonProperty("new_balance")]
        public int NewBalance { get; set; }
    }
}
