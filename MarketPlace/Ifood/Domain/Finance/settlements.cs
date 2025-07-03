using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class AccountDetails
    {
        public string bankName { get; set; }
        public string bankNumber { get; set; }
        public string branchCode { get; set; }
        public string accountNumber { get; set; }
        public string documentNumber { get; set; }
        public string accountDigit { get; set; }
        public string branchDigit { get; set; }
    }

    public class ClosingItem
    {
        public string id { get; set; }
        public string type { get; set; }
        public string product { get; set; }
        public double amount { get; set; }
        public string status { get; set; }
        public string transactionId { get; set; }
        public AccountDetails accountDetails { get; set; }
        public string paymentDate { get; set; }
    }

    public class SettlementRoot
    {
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public double balance { get; set; }
        public string merchantId { get; set; }
        public List<Settlement> settlements { get; set; }
        public List<string> consolidatedMerchants { get; set; }
    }

    public class Settlement
    {
        public string id { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public AccountDetails accountDetails { get; set; }
        public string paymentDate { get; set; }
        public string transactionId { get; set; }
        public string startDateCalculation { get; set; }
        public string endDateCalculation { get; set; }
        public List<ClosingItem> closingItems { get; set; }
    }
}
