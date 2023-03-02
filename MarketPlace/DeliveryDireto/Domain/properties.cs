using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class properties
    {
        public string priceCalculationType { get; set; }
        public string description { get; set; }
        public decimal? id { get; set; }
        public bool? isFractional { get; set; }
        public string name { get; set; }
        public decimal? orderPropertiesId { get; set; }
        public decimal? sequence { get; set; }
        public List<options> options { get; set; }
    }
}
