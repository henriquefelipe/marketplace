using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class chargeCancellations
    {
        public string merchantName { get; set; }
        public string paymentPlan { get; set; }
        public string periodId { get; set; }
        public string expectedPaymentDate { get; set; }
        public string transactionId { get; set; }
        public string transactionDate { get; set; }
        public string transactionDateTime { get; set; }
        public decimal amount { get; set; }
        public string orderId { get; set; }
        public string orderDate { get; set; }
        public string cancellationCode { get; set; }
        public string cancellationCodeDescription { get; set; }
    }
}
