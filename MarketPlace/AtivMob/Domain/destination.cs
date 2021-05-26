using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class destination
    {
        public destination()
        {
            phones = new List<phones>();
        }

        public seller seller { get; set; }
        public deliveryPlace deliveryPlace { get; set; }
        public IList<phones> phones { get; set; }
        public address address { get; set; }
    }
}
