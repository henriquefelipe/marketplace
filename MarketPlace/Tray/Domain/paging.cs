using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class paging
    {
        public int total { get; set; }
        public int page { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int maxLimit { get; set; }
    }
}
