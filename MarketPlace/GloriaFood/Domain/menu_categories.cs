using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class menu_categories
    {
        public menu_categories()
        {
            items = new List<menu_item>();
            groups = new List<menu_item_group>();
        }

        public int id { get; set; }
        public int menu_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public string active_begin { get; set; }
        public string active_end { get; set; }
        public int active_days { get; set; }
        public int sort { get; set; }
        public int? picture_id { get; set; }
        public string hidden_until { get; set; }
        public List<menu_item> items { get; set; }
        public List<menu_item_group> groups { get; set; }
    }
}
