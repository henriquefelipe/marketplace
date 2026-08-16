using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GoomerAbrahao.Domain
{
    public class OrderOption
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("option_id")]
        public string OptionId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("notes")]
        public List<string> Notes { get; set; }

        [JsonProperty("extra_fields")]
        public JObject ExtraFields { get; set; }

        [JsonIgnore]
        public decimal Total
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
