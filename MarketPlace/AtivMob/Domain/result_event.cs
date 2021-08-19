using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class result_event
    {
        public result_event()
        {
            events = new List<evento>();
        }

        public List<evento> events { get; set; }
    }
}
