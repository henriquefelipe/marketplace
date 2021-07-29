using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class eater
    {
        public string first_name { get; set; }
        public string phone { get; set; }
        public string phone_code { get; set; }
        public string last_name { get; set; }
        public eater_delivery delivery { get; set; }
    }

    public class eater_delivery
    {
        public eater_delivery_location location { get; set; }
        public string type { get; set; }
        public string notes { get; set; }
    }

    public class eater_delivery_location
    {
        public string google_place_id { get; set; }
        public string unit_number { get; set; }
        public string type { get; set; }
        public string street_address { get; set; }
    }
}
