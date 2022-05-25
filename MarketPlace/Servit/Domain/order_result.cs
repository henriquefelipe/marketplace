using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class order_result
    {
        public order_result()
        {
            orders = new List<order>();
        }

        public List<order> orders { get; set; }
    }
}
