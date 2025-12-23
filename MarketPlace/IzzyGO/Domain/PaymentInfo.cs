using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class PaymentInfo
    {
        public string Method { get; set; }
        public string Type { get; set; }
        public decimal? Value { get; set; }
        public string Currency { get; set; }
        public decimal? ChangeFor { get; set; }
    }
}
