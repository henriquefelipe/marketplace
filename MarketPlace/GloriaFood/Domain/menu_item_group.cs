using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class menu_item_group
    {
        public menu_item_group()
        {
            options = new List<menu_item_group_option>();
        }

        public int id { get; set; }
        public int menu_id { get; set; }
        public string name { get; set; }
        public int sort { get; set; }
        public bool required { get; set; }
        public int force_min { get; set; }
        public int force_max { get; set; }
        public bool allow_quantity { get; set; }
        public int tax_category_id { get; set; }
        public List<menu_item_group_option> options { get; set; }
    }
}
