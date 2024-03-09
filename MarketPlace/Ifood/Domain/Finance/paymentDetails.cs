using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class paymentDetails
    {
        public string orderId { get; set; }
        public PaymentDetailsPayment payment { get; set; }
    }

    public class PaymentDetailsPayment
    {
        public string status { get; set; }
        public string type { get; set; }
        public string method { get; set; }
        public string brand { get; set; }
        public string liability { get; set; }
        public string cardNumber { get; set; }
        public string acquirer { get; set; }
        public string nsu { get; set; }
        public string authCode { get; set; }
        public string refundType { get; set; }
        public string refundValue { get; set; }
        public string refundDate { get; set; }
        public string paymentDate { get; set; }
        public string updatedAt { get; set; }
    }
}
