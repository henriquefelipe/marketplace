using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class promotions
    {
        [JsonProperty("promotions")]
        public List<promotion> promotions_array { get; set; }
    }
}
