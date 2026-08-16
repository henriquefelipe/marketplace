using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class TableCard
    {
        [JsonProperty("active")]
        public int Active { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("service_percentage")]
        public decimal ServicePercentage { get; set; }
        [JsonProperty("qr_code")]
        public string QrCode { get; set; }
    }
}
