using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class packages
    {
        public string id { get; set; }
        public deliveryService deliveryService { get; set; }
        public packingList packingList { get; set; }
        public deadline deadline { get; set; }
        public shipping shipping { get; set; }
        public IList<volumes> volumes { get; set; }
        public invoice invoice { get; set; }
        public origin origin { get; set; }
        public destination destination { get; set; }
    }
}
