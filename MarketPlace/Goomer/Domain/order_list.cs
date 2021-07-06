using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Domain
{
    public class order_list
    {
        public order_list()
        {
            orders = new List<int>();
        }

        public List<int> orders { get; set; }
    }
}
