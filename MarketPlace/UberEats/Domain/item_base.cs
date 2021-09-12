using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class item_base
    {
        public item_base()
        {
            selected_modifier_groups = new List<item_group>();
        }

        public string id { get; set; }
        public string title { get; set; }
        public string external_data { get; set; }
        public decimal quantity { get; set; }
        public item_price price { get; set; }
        public List<item_group> selected_modifier_groups { get; set; }
        
    }
}
