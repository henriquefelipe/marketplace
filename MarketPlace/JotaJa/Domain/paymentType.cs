using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Domain
{
    public class paymentType
    {
        public decimal id { get; set; }
        public string createdAt { get; set; }
        public bool isActive { get; set; }
        public string type { get; set; }
        public string colibriId { get; set; }
        public string shortFormId { get; set; }
        public string apiGateway { get; set; }
    }
}
