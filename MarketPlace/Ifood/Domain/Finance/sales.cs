using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class sales
    {
        public string orderId { get; set; }
        public string orderDate { get; set; }
        public string lastProcessingDate { get; set; }
        public string orderStatus { get; set; }
        public string companyName { get; set; }
        public string documentNumber { get; set; }
        public string businessModelOrder { get; set; }
        public string periodId { get; set; }
        public string orderDateTime { get; set; }
        public string lastProcessingDateTime { get; set; }
        public string deliveryProviderType { get; set; }
        public string salesChannel { get; set; }
        public string displayId { get; set; }
        public payment payment { get; set; }
        public billing billing { get; set; }
        public transfer transfer { get; set; }
    }

    public class transfer
    {
        public string expectedTransferDate { get; set; }
        public expectedBankAccount expectedBankAccount { get; set; }
    }

    public class billing
    {
        public decimal gmv { get; set; }
        public decimal totalBag { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal benefitIfood { get; set; }
        public decimal benefitMerchant { get; set; }
        public decimal commission { get; set; }
        public decimal acquirerFee { get; set; }
        public decimal deliveryCommission { get; set; }
        public decimal commissionRate { get; set; }
        public decimal acquirerFeeRate { get; set; }
        public decimal anticipationFee { get; set; }
        public decimal anticipationFeeRate { get; set; }
        public decimal smallOrderFee { get; set; }
        public decimal totalDebit { get; set; }
        public decimal totalCredit { get; set; }
    }

    public class expectedBankAccount
    {
        public string bankNumber { get; set; }
        public string bankName { get; set; }
        public string branchCode { get; set; }
        public string branchCodeDigit { get; set; }
        public string accountNumber { get; set; }
        public string accountNumberDigit { get; set; }
    }

    public class payment
    {
        public string type { get; set; }
        public string method { get; set; }
        public string brand { get; set; }
        public string liability { get; set; }
        public string cardNumber { get; set; }
        public string nsu { get; set; }
    }
}
