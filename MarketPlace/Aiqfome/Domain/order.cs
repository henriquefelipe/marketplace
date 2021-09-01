using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order
    {
        public order()
        {
            items = new List<order_item>();
        }

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


        public string delivery_time { get; set; }
        public string coupon_hash { get; set; }
        public string order_observations { get; set; }
        public bool is_pickup { get; set; }
        public string pickup_at { get; set; }

        public List<order_item> items { get; set; }
        public order_user user { get; set; }
        public order_payment_method payment_method { get; set; }
        public order_store store { get; set; }
        public order_timeline timeline { get; set; }
        public order_aiqentrega aiqentrega { get; set; }
    }


}
