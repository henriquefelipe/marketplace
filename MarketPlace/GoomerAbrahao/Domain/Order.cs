using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("table")]
        public int? Table { get; set; }

        [JsonProperty("table_name")]
        public string TableName { get; set; }

        [JsonProperty("card")]
        public int? Card { get; set; }

        [JsonProperty("card_hash")]
        public string CardHash { get; set; }

        [JsonProperty("waiter")]
        public string Waiter { get; set; }

        [JsonProperty("square")]
        public string Square { get; set; }

        [JsonProperty("people")]
        public int? People { get; set; }

        [JsonProperty("is_paid")]
        public bool IsPaid { get; set; }

        [JsonProperty("take_away")]
        public bool TakeAway { get; set; }

        [JsonProperty("fiscal_print")]
        public bool FiscalPrint { get; set; }

        [JsonProperty("fiscal_document")]
        public string FiscalDocument { get; set; }

        [JsonProperty("payments")]
        public List<OrderPayment> Payments { get; set; }

        [JsonProperty("loyalty_use_discount")]
        public bool LoyaltyUseDiscount { get; set; }

        [JsonProperty("customer")]
        public OrderCustomer Customer { get; set; }

        [JsonProperty("items")]
        public List<OrderItem> Items { get; set; }

        [JsonIgnore]
        public string Reference
        {
            get { return Id.Replace("-", "").Substring(0, 6).ToUpper(); }
        }
    }
}
