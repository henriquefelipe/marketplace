using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string group_name { get; set; }
        public string type { get; set; }
        public int type_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }       
    }
}
