using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class event_result
    {
        public event_result()
        {
            events = new List<evento>();
        }

        public List<evento> events { get; set; }
    }

    public class evento
    {
        public int id { get; set; }
        public string origin { get; set; }
        public string model { get; set; }
        public string description { get; set; }        
        public string status { get; set; }

        public data data { get; set; }
        public order order { get; set; }
        public bill bill { get; set; }
        public table table { get; set; }
        public order_product order_product { get; set; }
    }
}
