using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class result_order<TResult>
    {
        public string status { get; set; }
        public string message { get; set; }
        public string date { get; set; }
        public int numFound { get; set; }
        public TResult body { get; set; }

        
    }
}
