using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class ResponseOrderNewItem
    {
        [JsonProperty("new_item")]
        public OrderItem NewItem { get; set; }
    }
}
