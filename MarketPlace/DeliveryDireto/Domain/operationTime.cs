using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class operationTime
    {
        public decimal approvedBy { get; set; }
        public string approvedTime { get; set; }
        public decimal cancelledBy { get; set; }
        public string cancelledTime { get; set;}
        public decimal doneBy { get; set; }
        public string doneTime { get; set; }
        public decimal inTransitBy { get; set; }
        public string inTransitTime { get; set; }
        public decimal editedBy { get; set; }
        public string editedTime { get; set;}
    }
}
