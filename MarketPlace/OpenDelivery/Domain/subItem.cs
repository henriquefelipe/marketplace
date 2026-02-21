using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class subItem
    {
        public int index { get; set; }
        public string name { get; set; }
        public string externalCode { get; set; }
        public decimal quantity { get; set; }
        public string unit { get; set; }        
        public value_currency unitPrice { get; set; }
        public value_currency totalPrice { get; set; }
        //public decimal discount { get; set; }
        //public decimal addition { get; set; }
        
        //public string observations { get; set; }
    }
}
