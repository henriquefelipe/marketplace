using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class OrderCustomer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("document")]
        public string Document { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
