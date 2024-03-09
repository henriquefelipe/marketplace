using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class salesBenefits
    {
        public string orderId { get; set; }
        public string displayId { get; set; }
        public string orderDate { get; set; }
        public string totalAmount { get; set; }
        public string taxPolAmount { get; set; }
        public string netAmount { get; set; }
        public string merchantId { get; set; }
        public string documentNumber { get; set; }
        public string periodId { get; set; }
        public string expectedPaymentDate { get; set; }
    }
}
