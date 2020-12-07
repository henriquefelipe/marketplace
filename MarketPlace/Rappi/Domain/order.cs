using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Domain
{
    public class order
    {
        public order_detail order_Detail { get; set; }
        public customer customer { get; set; }
        public store store { get; set; }
    }    
}
