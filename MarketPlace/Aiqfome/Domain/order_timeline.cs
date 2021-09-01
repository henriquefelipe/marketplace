using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order_timeline
    {
        public string created_at { get; set; }
        public string read_at { get; set; }
        public string cancelled_at { get; set; }
        public string ready_at { get; set; }
        public string timezone { get; set; }
    }
}
