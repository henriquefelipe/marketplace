using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order_aiqentrega
    {
        public string ride_id { get; set; }
        public string call_at { get; set; }
        public string current_status { get; set; }
        public string delivered_at { get; set; }
        public string last_status { get; set; }
        public string last_status_at { get; set; }
        public string driver_name { get; set; }
        public string driver_phone { get; set; }
    }
}
