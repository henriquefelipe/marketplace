using System;
using System.Collections.Generic;
using System.Text;

namespace ADAC.Domain
{
    public class item
    {
        public decimal totalPrice { get; set; }
        public string externalCode { get; set; }
        public decimal optionsPrice { get; set; }
        public decimal customizationPrice { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public string observations { get; set; }
        public List<option> options { get; set; }
    }

    public class option
    {
        public string name { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public decimal addition { get; set; }
        public decimal quantity { get; set; }
        public string externalCode { get; set; }
        //public List<object> customizations { get; set; }
    }
}
