using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class compositeItems
    {
        public string priceCalculationType { get; set; }
        public price propertiesPrice { get; set; }
        public price total { get; set; }
        public decimal amount { get; set; }
        public string customCode { get; set; }
        public string comments { get; set; }
        public decimal id { get; set; }
        public string name { get; set; }
        public decimal ordersItemsId { get; set; }
        public decimal sequence { get; set; }
        public List<itemsComposite> items { get; set; }
        public properties properties { get; set; }
    }
}
