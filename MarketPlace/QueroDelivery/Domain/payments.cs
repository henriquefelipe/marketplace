using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class payments
    {
        public decimal prepaid { get; set; }
        public decimal pending { get; set; }
        public List<methods> methods { get; set; }
    }
}
