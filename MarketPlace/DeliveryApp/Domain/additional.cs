using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class additional
    {
        public additional()
        {
            Additionals = new List<additional_item>();
        }

        public string title { get; set; }
        public bool text_input { get; set; }

        public List<additional_item> Additionals { get; set; }
    }

    public class additional_item
    {
        [JsonProperty("ref")]
        public string refe { get; set; }
        public decimal quantity { get; set; }
        public decimal price_un { get; set; }
        public string text_input { get; set; }
        public string title { get; set; }
    }
}
