using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class discounts
    {
        public price amount { get; set; }
        public string target { get; set; }
        public string targetId { get; set; }
        public List<sponsorshipValues> sponsorshipValues { get; set; }
    }
}
