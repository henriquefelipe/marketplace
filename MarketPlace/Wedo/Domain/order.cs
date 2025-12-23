using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Domain
{
    public class order
    {
        public string id { get; set; }
        public string type { get; set; }
        public int seq { get; set; }
        public string taxPayerIdentification { get; set; }
        public string entregafacilId { get; set; }
        public string deliveryType { get; set; }
        public string feePaidPrice { get; set; }
        public string notes { get; set; }
        public merchant merchant { get; set; }
        public customer customer { get; set; }
        public List<item> items { get; set; }
        public decimal changeFor { get; set; }
        public payment payment { get; set; }
        public decimal subTotal { get; set; }
        public decimal orderTotal { get; set; }
        public decimal deliveryFee { get; set; }

        public DeliveryAddress deliveryAddress { get; set; }

        public scheduledOrder scheduledOrder { get; set; }
    }
}
