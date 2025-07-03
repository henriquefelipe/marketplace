using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class AnticipationsSettlementClosingItemAccountDetails
    {
        public string bankName { get; set; }
        public string bankNumber { get; set; }
        public string branchCode { get; set; }
        public object branchDigit { get; set; }
        public string accountNumber { get; set; }
        public string accountDigit { get; set; }
        public object documentNumber { get; set; }
    }

    public class AnticipationsSettlementClosingItem
    {
        public string type { get; set; }
        public double originalPaymentAmount { get; set; }
        public double feePercentage { get; set; }
        public double feeAmount { get; set; }
        public double anticipatedPaymentAmount { get; set; }
        public string status { get; set; }
        public AnticipationsSettlementClosingItemAccountDetails accountDetails { get; set; }
        public string originalPaymentDate { get; set; }
        public string anticipatedPaymentDate { get; set; }
    }

    public class Anticipations
    {
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public double balance { get; set; }
        public string merchantId { get; set; }
        public List<AnticipationsSettlement> settlements { get; set; }
    }

    public class AnticipationsSettlement
    {
        public string startDateCalculation { get; set; }
        public string endDateCalculation { get; set; }
        public List<AnticipationsSettlementClosingItem> closingItems { get; set; }
    }
}
