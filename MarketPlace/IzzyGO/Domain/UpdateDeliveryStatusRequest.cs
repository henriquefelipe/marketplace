using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class UpdateDeliveryStatusRequest
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
