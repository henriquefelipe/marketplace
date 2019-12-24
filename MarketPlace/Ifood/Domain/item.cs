using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class item
    {
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public decimal subItemsPrice { get; set; }
        public decimal totalPrice { get; set; }
        public decimal discount { get; set; }
        public string addition { get; set; }
        public string externalCode { get; set; }
    }
}
