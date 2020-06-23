using System.Collections.Generic;

namespace Logaroo.Domain
{
    public class payments
    {
        public paymentsData data { get; set; }
    }

    public class paymentsData
    {        
        public List<paymentsItems> items { get; set; }
        public int totals { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
    }

    public class paymentsItems
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string reference_id { get; set; }
        public int status { get; set; }
    }   
}
