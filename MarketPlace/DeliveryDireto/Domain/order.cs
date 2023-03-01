using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class order
    {
        public string created { get; set; }
        public decimal customerOrderNumber { get; set; }
        public decimal id { get; set; }
        public bool isNewCustomer { get; set; }
        public bool isRegisteredInvoice { get; set; }
        public string modified { get; set; }
        public string notes { get; set; }
        public decimal orderNumber { get; set; }
        public string registeredDocument { get; set; }
        public string status { get; set; }
        public string statusReason { get; set; }
        public string type { get; set; }
        public totals total { get; set; }
        public operationTime operationTime { get; set; }
        public metadata metadata { get; set; }
        public customer customer { get; set; }
        public string source { get; set; }
        public paymentMethod paymentMethod { get; set; }
        public List<items> items { get; set; }
        public List<compositeItems> compositeItems { get; set; }
        public scheduledOrder scheduledOrder { get; set; }
        public address address { get; set; }
        public voucher voucher { get; set; }
        public loyaltyprogram loyaltyprogram { get; set; }
        public memberGetMember memberGetMember { get; set; }
        public deliveryArea deliveryArea { get; set; }
        public table table { get; set; }
        public bool? isCanceled { get; set; }
        public bool? isOnlinePayment { get; set; }
        public loyaltyprogramReward loyaltyprogramReward { get; set; }
    }
}
