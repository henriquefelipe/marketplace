using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoopIzy.Domain
{
    public class OrderRequest
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("items")]
        public List<OrderItem> Items { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("sale_date")]
        public string SaleDate { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("merchant")]
        public string Merchant { get; set; }
    }

    public class OrderItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sku")]
        public string sku { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
    }

    public class OrderResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("points_credited")]
        public int PointsCredited { get; set; }

        [JsonProperty("new_balance")]
        public int NewBalance { get; set; }
    }

    public class ReverseOrderRequest
    {
        [JsonProperty("action")]
        public string Action => "reverse";

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    public class ReverseOrderResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("points_debited")]
        public int PointsDebited { get; set; }

        [JsonProperty("new_balance")]
        public int NewBalance { get; set; }

        [JsonProperty("coupon_released")]
        public bool CouponReleased { get; set; }

        [JsonProperty("cashback_reversed")]
        public bool CashbackReversed { get; set; }
    }
}
