using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class order
    {
        public string id { get; set; }
        public string display_id { get; set; }
        public string current_state { get; set; }
        public store store { get; set; }
        public eater eater { get; set; }
        public cart cart { get; set; }
        public payment payment { get; set; }
        public string placed_at { get; set; }
        public string estimated_ready_for_pickup_at { get; set; }

        //[JsonProperty("@type")]
        public string type { get; set; }
        public List<eaters> eaters { get; set; }
        public string brand { get; set; }             
    }
}
