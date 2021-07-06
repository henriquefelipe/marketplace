using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class user
    {
        public string name { get; set; }
        public string document { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int totalOrders { get; set; }
    }
}
