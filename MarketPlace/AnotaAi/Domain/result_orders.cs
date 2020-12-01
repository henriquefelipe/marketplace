using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Domain
{
    public class result_orders
    {
        public bool success { get; set; }
        public result_orders_info info { get; set; }
        public int count { get; set; }
        public int limit { get; set; }
        public int currentpage { get; set; }
    }

    public class result_orders_info
    {
        public List<result_orders_info_doc> docs { get; set; }
    }

    public class result_orders_info_doc
    {
        public string _id { get; set; }
        public int check { get; set; }
    }
}
