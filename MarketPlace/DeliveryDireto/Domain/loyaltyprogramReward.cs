using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class loyaltyprogramReward
    {
        public decimal? id { get; set; }
        public decimal? loyaltyprogramId { get; set; }
        public string benefitValue { get; set; }
        public string customCode { get; set; }
    }
}
