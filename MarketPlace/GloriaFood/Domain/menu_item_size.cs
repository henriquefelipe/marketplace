using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class menu_item_size
    {
        public menu_item_size()
        {
            groups = new List<menu_item_group>();
        }

        public int id { get; set; }
        public int menu_item_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        //public bool default { get; set; }
        public List<menu_item_group> groups { get; set; }
                            
    }
}
