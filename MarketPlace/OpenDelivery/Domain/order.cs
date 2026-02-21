using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class order
    {
        public order()
        {
            items = new List<item>();
            benefits = new List<benefits>();
            additionalFees = new List<additionalFees>();
        }

        public string id { get; set; }
        public string type { get; set; }
        public string createdAt { get; set; }
        public string preparationStartDateTime { get; set; }
        public string orderTiming { get; set; }
        public string displayId { get; set; }
        public merchant merchant { get; set; }
        public payment payments { get; set; }
        public customer customer { get; set; }
        public List<item> items { get; set; }
        public total total { get; set; }
        public delivery delivery { get; set; }
        public List<benefits> benefits { get; set; }
        public List<additionalFees> additionalFees { get; set; }
        public picking picking { get; set; }
        public string extraInfo { get; set; }
        public schedule schedule { get; set; }
        public indoor indoor { get; set; }
        public takeout takeout { get; set; }
    }
}
