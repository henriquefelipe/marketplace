using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class delivery
    {
        public delivery_location location { get; set; }        
        public string type { get; set; }
        public string notes { get; set; }
    }

    public class delivery_location
    {
        public string google_place_id { get; set; }
        public string unit_number { get; set; }
        public string type { get; set; }
        public string street_address { get; set; }
    }
}
