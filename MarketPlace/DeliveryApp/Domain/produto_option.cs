using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class produto_option
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price_un { get; set; }
        public int quantity { get; set; }

        [JsonProperty(PropertyName = "ref")]
        public string _ref { get; set; }
        public string ref_sabor_tamanho { get; set; }
        public decimal subtotal { get; set; }
    }
}
