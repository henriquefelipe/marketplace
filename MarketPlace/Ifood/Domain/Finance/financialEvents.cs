using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class Amount
    {
        public string value { get; set; }
    }

    public class Billing
    {
        public string baseValue { get; set; }
        public string feePercentage { get; set; }
    }

    public class FinancialEvent
    {
        public string name { get; set; }
        public string description { get; set; }
        public string product { get; set; }
        public string trigger { get; set; }
        public string competence { get; set; }
        public Period period { get; set; }
        public Reference reference { get; set; }
        public bool hasTransferImpact { get; set; }
        public Amount amount { get; set; }
        public Billing billing { get; set; }
        public FinancialEventSettlement settlement { get; set; }
        public Receiver receiver { get; set; }
        public Payment payment { get; set; }
    }

    public class Payment
    {
        public string method { get; set; }
        public string liability { get; set; }
        public string brand { get; set; }
    }

    public class Period
    {
        public string beginDate { get; set; }
        public string endDate { get; set; }
    }

    public class Receiver
    {
        public string businessId { get; set; }
        public string businessType { get; set; }
        public string businessDocument { get; set; }
    }

    public class Reference
    {
        public string type { get; set; }
        public string id { get; set; }
        public DateTime date { get; set; }
    }

    public class FinancialEventsRoots
    {
        public int page { get; set; }
        public int size { get; set; }
        public bool hasNextPage { get; set; }
        public List<FinancialEvent> financialEvents { get; set; }
    }

    public class FinancialEventSettlement
    {
        public string expectedDate { get; set; }
    }

}
