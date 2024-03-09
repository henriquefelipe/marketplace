using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class cancellations
    {
        public string merchantName { get; set; }
        public string merchantId { get; set; }
        public string orderId { get; set; }
        public string cancellationDate { get; set; }
        public string orderDate { get; set; }
        public decimal amount { get; set; }
        public string liability { get; set; }
        public string operationType { get; set; }
        public string displayId { get; set; }
        public string periodId { get; set; }
        public string cancellationCode { get; set; }
        public string cancellationCodeDescription { get; set; }
    }
}
