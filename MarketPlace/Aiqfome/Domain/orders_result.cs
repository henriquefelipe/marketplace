using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class orders_result
    {
        public orders_result()
        {
            data = new List<orders_result_order>();
        }

        public List<orders_result_order> data { get; set; }
        public orders_links_result links { get; set; }
        public orders_meta_result meta { get; set; }
    }

    public class orders_result_order
    {
        public int order_id { get; set; }
        public string created_at { get; set; }
        public bool is_ready { get; set; }
        public bool is_read { get; set; }
        public bool is_cancelled { get; set; }
        public string user_name { get; set; }
        public bool is_aiqentrega_delivery { get; set; }
        public bool order_is_pickup { get; set; }
        public string store_id { get; set; }
        public string store_name { get; set; }
        public string order_delivery_time { get; set; }        
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
