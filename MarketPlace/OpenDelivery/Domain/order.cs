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
            otherFees = new List<otherFees>();
            discounts = new List<discounts>();            
        }

        public string id { get; set; }
        public string type { get; set; }
        public string displayId { get; set; }
        public string sourceAppId { get; set; }
        public string salesChannel { get; set; }
        public string virtualBrand { get; set; }
        public string category { get; set; }
        public string createdAt { get; set; }
        public string lastEvent { get; set; }
        public string orderTiming { get; set; }
        public string preparationStartDateTime { get; set; }
        
        
        public merchant merchant { get; set; }
        public List<item> items { get; set; }
        public List<otherFees> otherFees { get; set; }
        public List<discounts> discounts { get; set; }
        public total total { get; set; }
        public payment payments { get; set; }
        public taxInvoice taxInvoice { get; set; }
        public customer customer { get; set; }
        public schedule schedule { get; set; }
        public string orderPriority { get; set; }
        public delivery delivery { get; set; }
        public takeout takeout { get; set; }
        public indoor indoor { get; set; }
        public bool sendPreparing { get; set; }
        public bool sendDelivered { get; set; }
        public bool sendPickedUp { get; set; }
        public bool sendTracking { get; set; }               
        public string extraInfo { get; set; }        
    }
}
