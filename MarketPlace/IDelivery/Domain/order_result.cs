using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDelivery.Domain
{
    public class order_result
    {
        public order_result()
        {
            data = new List<order>();
        }

        public bool success { get; set; }
        public string message { get; set; }
        public List<order> data { get; set; }
    }
}
