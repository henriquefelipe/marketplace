using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedreiroDigital.Domain
{
    public class result_order
    {
        public result_order()
        {
            requests = new List<order>();
        }

        public List<order> requests { get; set; }
    }
}
