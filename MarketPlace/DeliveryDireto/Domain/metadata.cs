using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class metadata
    {
        public string source { get; set; }
        public string utmSource { get; set; }
        public string utmMedium { get; set; }
        public string utmCampaign { get; set; }
        public string utmTerm { get; set; }
        public string utmContent { get; set; }
        public store store { get; set; }
    }
}
