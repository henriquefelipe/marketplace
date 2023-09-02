using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Domain
{
    public class item
    {
        public string id { get; set; }
        public string uniqueId { get; set; }
        public int index { get; set; }
        public string name { get; set; }
        public string externalCode { get; set; }
        public string unit { get; set; }
        public string ean { get; set; }
        public decimal quantity { get; set; }
        public string observations { get; set; }
        public decimal addition { get; set; }
        public decimal price { get; set; }
        public decimal unitPrice { get; set; }
        public decimal optionsPrice { get; set; }
        public decimal totalPrice { get; set; }
        public string imageUrl { get; set; }       
    }
}
