using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Domain
{
    public class payment
    {
        public string title { get; set; }
        public decimal change { get; set; }
        public string type { get; set; }
        public string selectedCardType { get; set; }
    }
}
