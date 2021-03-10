using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class complement_categorie
    {
        public complement_categorie()
        {
            Complements = new List<complement>();
        }

        public string title { get; set; }
        public int tipo { get; set; }
        public List<complement> Complements { get; set; }
    }

    public class complement
    {
        public int quantity { get; set; }
        public string title { get; set; }
        public decimal price_un { get; set; }
        public decimal total { get; set; }

        [JsonProperty(PropertyName = "ref")]
        public string _ref { get; set; }
    }
}
