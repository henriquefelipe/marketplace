using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class menu_item_group_option
    {
        public int id { get; set; }
        public int option_group_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        //public bool default { get; set; }
        public int sort { get; set; }
}
}
