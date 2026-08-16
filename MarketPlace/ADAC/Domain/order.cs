using System;
using System.Collections.Generic;
using System.Text;

namespace ADAC.Domain
{
    public class order
    {
        public string id { get; set; }
        public string storeId { get; set; }
        public string shortReference { get; set; }
        public DateTime createdAt { get; set; }
        public string type { get; set; }
        public customer customer { get; set; }
        public List<item> items { get; set; }
        public total total { get; set; }
        public List<payment> payments { get; set; }
        public deliveryAddress deliveryAddress { get; set; }
    }
}
