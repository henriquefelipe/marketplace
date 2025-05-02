using System;
using System.Collections.Generic;
using System.Text;

namespace Repediu.Domain
{
    public class order
    {
        public order() 
        {
            items = new List<item>();
            type = "DELIVERY";
            orderTiming = "INSTANT";
            otherFees = new List<otherFees>();
        }

        public string id { get; set; }
        public string type { get; set; }
        public string displayId { get; set; }
        public string sourceAppId {  get; set; }
        public string salesChannel { get; set; }
        public string storeChannel { get; set; }
        public string createdAt { get; set; }
        public string orderTiming { get; set; }
        public string preparationStartDateTime { get; set; }    
        public merchant merchant { get; set; }
        public customer customer { get; set; }
        public delivery delivery { get; set; }  
        public payments payments { get; set; }
        public total total { get; set; }
        public List<item> items { get; set; }
        public List<otherFees> otherFees { get; set; }
    }
}
