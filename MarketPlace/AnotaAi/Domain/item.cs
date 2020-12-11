using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Domain
{
    public class item
    {
        public string externalId { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal totalPrice { get; set; }
        public decimal unitPrice { get; set; }
        public decimal new_totalPrice { get; set; }
        public decimal new_unitPrice { get; set; }
        public string observation { get; set; }
        public List<subitem> subItems { get; set; }
    }

    public class subitem
    {
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal totalPrice { get; set; }
        public decimal unitPrice { get; set; }
        public decimal new_totalPrice { get; set; }
        public decimal new_unitPrice { get; set; }
        public string externalCode { get; set; }
        public string externalId { get; set; }
    }
}
