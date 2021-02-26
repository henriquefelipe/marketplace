using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class result_order
    {
        public result_order()
        {
            Orders = new List<order>();
            causes = new List<causes>();
        }

        public int code { get; set; }
        public string name { get; set; }
        public List<order> Orders { get; set; }
        public order Order { get; set; }
        public List<causes> causes { get; set; }

    }

    public class causes
    {
        public string message { get; set; }
    }
}
