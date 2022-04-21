using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class promotionGroupOrders
    {
        public promotionGroupOrders()
        {
            Products = new List<produto>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal quantidade { get; set; }
        public string notes { get; set; }
        public int type { get; set; }
        public decimal value { get; set; }
        public decimal total { get; set; }

        [JsonProperty(PropertyName = "ref")]
        public decimal _ref { get; set; }
        public promotionGroupOrders_bonus bonus { get; set; }
        public List<produto> Products { get; set; }
    }

    public class promotionGroupOrders_bonus
    {
        public int type { get; set; }
        //"value":null
    }

}
