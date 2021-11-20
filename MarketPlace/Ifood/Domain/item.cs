using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class item
    {
        public item()
        {
            options = new List<subItem>();
        }

        public int index { get; set; }
        public string name { get; set; }
        public string externalCode { get; set; }
        public string unit { get; set; }
        public decimal quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal price { get; set; }
        public decimal totalPrice { get; set; }
        public decimal optionsPrice { get; set; }                
        public decimal addition { get; set; }

        //public decimal discount { get; set; }
        public string observations { get; set; }

        public List<subItem> options { get; set; }
    }
}
