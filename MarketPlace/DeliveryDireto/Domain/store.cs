using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class store
    {
        public decimal? id { get; set; }
        public string deliverydiretoId { get; set; }
        public string name { get; set; }
        public string companyName { get; set; }
        public decimal? lat { get; set; }
        public decimal? lng { get; set; }
        public decimal? minWaitingTime { get; set; }
        public decimal? maxWaitingTime { get; set; }
        public string document { get; set; }
    }
}
