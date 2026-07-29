using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class OrderItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("options")]
        public List<OrderOption> Options { get; set; }

        [JsonProperty("notes")]
        public List<string> Notes { get; set; }

        [JsonProperty("extra_fields")]
        public JObject ExtraFields { get; set; }

        [JsonIgnore]
        public decimal Total { get
            {
                return (Quantity * Price) + Options.Sum(s => s.Total);
            }
        }
    }
}
