using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu.Domain
{
    public class item
    {
        public item()
        {
            subItems = new List<subItem>();
        }

        public string reference { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public decimal subItemsPrice { get; set; }
        public decimal totalPrice { get; set; }
        public decimal discount { get; set; }        
        public string externalCode { get; set; }
        public string observations { get; set; }

        public List<subItem> subItems { get; set; }
    }
}
