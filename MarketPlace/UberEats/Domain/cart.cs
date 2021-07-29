using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class cart
    {
        public cart()
        {
            items = new List<item>();
        }

        public List<item> items { get; set; }
        public string version_id { get; set; }
         //"fulfillment_issues": []
    }
}
