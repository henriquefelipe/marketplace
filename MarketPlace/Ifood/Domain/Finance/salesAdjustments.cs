using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class salesAdjustments
    {
        public string orderId { get; set; }
        public string billedOrderId { get; set; }
        public string periodId { get; set; }
        public string documentNumber { get; set; }
        public string orderDate { get; set; }
        public string orderDateUpdate { get; set; }
        public string orderDateTimeUpdate { get; set; }
        public decimal adjustmentAmount { get; set; }
        public string expectedPaymentDate { get; set; }
        public billing billedOrderUpdate { get; set; }
        public string displayId { get; set; }
        public string cancellationCode { get; set; }
        public string cancellationCodeDescription { get; set; }
    }
}
