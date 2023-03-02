using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class options
    {
        public price price { get; set; }
        public decimal? amount { get; set; }
        public string customCode { get; set; }
        public string description { get; set; }
        public decimal? id { get; set; }
        public string name { get; set; }
        public decimal? ordersOptionsId { get; set; }
        public decimal? sequence { get; set; }
    }
}
