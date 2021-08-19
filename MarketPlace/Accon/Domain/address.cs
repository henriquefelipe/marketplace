using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class address
    {
        public latlng latlng { get; set; }
        public bool is_active { get; set; }
        public string created_at { get; set; }
        public string _id { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }

        [JsonProperty("address")]
        public string _address { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string district { get; set; }
        public string name { get; set; }
    }
}
