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

        public int index { get; set; }
        public string id { get; set; }
        public string name { get; set; }        
        public string externalCode { get; set; }
        public string unit { get; set; }
        public string ean { get; set; }
        public decimal quantity { get; set; }
        public value_currency unitPrice { get; set; }        
        public value_currency totalPrice { get; set; }       
       
        public string specialInstructions { get; set; }        

        public List<subItem> options { get; set; }        
    }   
}
