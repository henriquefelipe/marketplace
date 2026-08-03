using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class ResponseOrders : Response<List<Order>>
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
