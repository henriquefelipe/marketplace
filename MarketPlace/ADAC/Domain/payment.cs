using System;
using System.Collections.Generic;
using System.Text;

namespace ADAC.Domain
{
    public class payment
    {
        public string type { get; set; }
        public decimal value { get; set; }
        public bool prepaid { get; set; }
        public decimal change { get; set; }
    }
}
