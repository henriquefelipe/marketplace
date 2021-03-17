using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipedi.Domain
{
    public class benefits
    {
        public decimal value { get; set; }
        public string target { get; set; }
        public sponsorshipValues sponsorshipValues { get; set; }        
    }

    public class sponsorshipValues
    {
        public decimal IFOOD { get; set; }
        public decimal MERCHANT { get; set; }
    }
}
