using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class picking
    {
        public string picker { get; set; }
        public string replacementOptions { get; set; } // STORE_CHOOSE_OTHER_ITEMS
    }
}
