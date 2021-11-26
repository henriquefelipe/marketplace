using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
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
    }

    public class sponsorshipValues
    {
        public string name { get; set; }
        public decimal value { get; set; }
    }
}
