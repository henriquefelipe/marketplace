using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class menu_item
    {
        public menu_item()
        {
            sizes = new List<menu_item_size>();
            groups = new List<menu_item_group>();
        }

        public int id { get; set; }
        public int menu_category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public bool active { get; set; }
        public string active_begin { get; set; }
        public string active_end { get; set; }
        public int active_days { get; set; }
        public int sort { get; set; }
        // "tags": [],
        public string hidden_until { get; set; }
        public int tax_category_id { get; set; }
        public bool hide_instructions { get; set; }
        public List<menu_item_size> sizes { get; set; }
        public List<menu_item_group> groups { get; set; }
                  
    }
}
