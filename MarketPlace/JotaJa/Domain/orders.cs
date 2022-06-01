using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Domain
{
    public class orders
    {
        public orders()
        {
            items = new List<order>();
        }

        public int offset { get; set; }
        public int limit { get; set; }
        public int totalItems { get; set; }
        public List<order> items { get; set; }
    }
}
