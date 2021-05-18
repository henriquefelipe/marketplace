using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class deliveryPlace
    {
        public distributionCenter distributionCenter { get; set; }
        public store store { get; set; }
        public customer customer { get; set; }
    }
}
