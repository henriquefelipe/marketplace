using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class payments
    {
        public string id { get; set; }
        public string periodId { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string expectedExecutionDate { get; set; }
        public string nextExecutionDate { get; set; }
        public string confirmedPaymentDate { get; set; }
        public decimal totalAmount { get; set; }
        public paymentsBankAccount bankAccount { get; set; }
        public List<string> merchantsConsolidated { get; set; }
        public string transactionCode { get; set; }
    }

    public class paymentsBankAccount
    {
        public string bankName { get; set; }
        public string bankNumber { get; set; }
        public string number { get; set; }
        public string numberDigit { get; set; }
        public string branchCode { get; set; }
        public string branchCodeDigit { get; set; }
        public paymentsDocument document { get; set; }
    }

    public class paymentsDocument
    {
        public string type { get; set; }
        public string number { get; set; }
        public string documentHolderName { get; set; }
    }
}
