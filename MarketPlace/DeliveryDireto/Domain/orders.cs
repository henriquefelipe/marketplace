using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class orders
    {
        [JsonProperty(PropertyName = "@class")]
        public string _class { get; set; }

        public List<string> codPedido { get; set; }
    }
}
