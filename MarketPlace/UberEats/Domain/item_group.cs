using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class item_group
    {
        public item_group()
        {
            selected_items = new List<item_group_item>();
        }

        public string id { get; set; }
        public string title { get; set; }
        public List<item_group_item> selected_items { get; set; }
        public string removed_items { get; set; }
    }
}
