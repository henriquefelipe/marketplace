using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class benefits
    {
        public benefits()
        {
            sponsorshipValues = new List<sponsorshipValues>();
        }

        public decimal value { get; set; }
        public string target { get; set; }
        public string targetId { get; set; }
        public List<sponsorshipValues> sponsorshipValues { get; set; }       
        public campaign campaign { get; set; }
    }

    public class sponsorshipValues
    {
        public string name { get; set; }
        public decimal value { get; set; }
        public string description { get; set; }
    }

    public class campaign
    {
        public string id { get; set; }        
        public string name { get; set; }
    }
}
