using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Domain
{
    public class stores
    {
        public stores()
        {
            items = new List<store>();
        }

        public int offset { get; set; }
        public int limit { get; set; }
        public int totalItems { get; set; }
        public List<store> items { get; set; }
    }
}
