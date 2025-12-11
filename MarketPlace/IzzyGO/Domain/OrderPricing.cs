using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class OrderPricing
    {
        public decimal? TotalPrice { get; set; }
        public string TotalCurrency { get; set; }
        public decimal? DeliveryFee { get; set; }
        public string DeliveryFeeCurrency { get; set; }
    }
}
