using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class options
    {
        public int index { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string externalCode { get; set; }
        public string unit { get; set; }
        public string ean { get; set; }
        public string calculationType { get; set; }
        public decimal quantity { get; set; }
        public string specialInstructions { get; set; }
        public price unitPrice { get; set; }
        public price totalPrice { get; set; }
    }
}