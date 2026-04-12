using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class discounts
    {
        public discounts()
        {
            sponsorshipValues = new List<sponsorshipValues>();
        }

        public value_currency amount { get; set; }
        public string target { get; set; }
        public string targetId { get; set; }
        public List<sponsorshipValues> sponsorshipValues { get; set; }               
    }

    public class sponsorshipValues
    {
        public string name { get; set; }
        public value_currency amount { get; set; }
        public string discountCode { get; set; }
    }   
}
