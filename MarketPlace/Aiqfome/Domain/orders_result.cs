using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class orders_result
    {        
        //public data data { get; set; }
        public orders_links_result links { get; set; }
        public orders_meta_result meta { get; set; }
    }

    public class orders_links_result
    {
        public string first { get; set; }
        public string last { get; set; }
        public string prev { get; set; }
        public string next { get; set; }
    }

    public class orders_meta_result
    {
        public int current_page { get; set; }
        public string from { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public string to { get; set; }
    }
}
