using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class item
    {
        public item()
        {
            options = new List<subItem>();
        }

        public string id { get; set; }
        public int index { get; set; }        
        public string name { get; set; }        
        public string externalCode { get; set; }
        public string unit { get; set; }
        public string ean { get; set; }
        public decimal quantity { get; set; }
        public string specialInstructions { get; set; }
        public value_currency unitPrice { get; set; }
        public value_currency originaltPrice { get; set; }
        public bool scalePriceApplied { get; set; }
        public value_currency optionsPrice { get; set; }
        public value_currency subtotalPrice { get; set; }
        public value_currency totalPrice { get; set; }
        public item_indoor indoor { get; set; }
        public List<subItem> options { get; set; }        
    }   

    public class item_indoor
    {
        public string productionPoint  { get; set; }
    }
}
