using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class ResponseTableCard : Response<List<TableCard>>
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
