using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Domain
{
    public class scheduledOrder
    {
        public string date { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string minTime { get; set; }
    }
}
