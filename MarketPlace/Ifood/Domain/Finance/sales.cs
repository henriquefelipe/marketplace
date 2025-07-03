using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Finance
{
    public class SalesRoot
    {
        public int page { get; set; }
        public int size { get; set; }
        public string beginSalesDate { get; set; }
        public string endSalesDate { get; set; }
        public List<Sale> sales { get; set; }
        public int total { get; set; }
        public int pageCount { get; set; }
    }


    public class BillingSummary
    {
        public int saleBalance { get; set; }
        public List<object> billingEntries { get; set; }
    }

    public class CancellationDispute
    {
        public bool automaticRefund { get; set; }
        public string reason { get; set; }
        public string isContestable { get; set; }
        public List<string> reasons { get; set; }
    }

    public class Card
    {
        public string brand { get; set; }
    }

    public class Delivery
    {
        public InformationProvider informationProvider { get; set; }
        public string type { get; set; }
        public DeliveryParameters deliveryParameters { get; set; }
        public Prices prices { get; set; }
    }

    public class DeliveryParameters
    {
        public string logisticProvider { get; set; }
        public string deliveryProduct { get; set; }
        public string code { get; set; }
        public string schedulingType { get; set; }
    }

    public class Document
    {
        public string value { get; set; }
        public string type { get; set; }
    }

    public class InformationProvider
    {
        public string name { get; set; }
    }

    public class Merchant
    {
        public string id { get; set; }
        public int shortId { get; set; }
        public List<Document> documents { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string timezone { get; set; }
    }

    public class Metadata
    {
        public string cancelStage { get; set; }
        public string cancelOrigin { get; set; }
        public string cancelCode { get; set; }
        public string cancelCodeDescription { get; set; }
        public CancellationDispute cancellationDispute { get; set; }
        public string originType { get; set; }
        public string createdAt { get; set; }
        public Metadata metadata { get; set; }
        public string originId { get; set; }
        public string orderId { get; set; }
        public string tribe { get; set; }
        public string id { get; set; }
        public string source { get; set; }
        public Refund refund { get; set; }
        public Payout payout { get; set; }
        public string orderAmount { get; set; }
        public string merchantId { get; set; }
        public string paymentLiability { get; set; }
        public string cancellationRequestSource { get; set; }
        public string paymentMethod { get; set; }
        public string type { get; set; }
        public string cancellationId { get; set; }
        public string paymentType { get; set; }
        public bool? isTestOrder { get; set; }
        public string salesChannel { get; set; }
        public string category { get; set; }
        public string refundId { get; set; }
    }

    public class PaymentsMethod
    {
        public string method { get; set; }
        public string currency { get; set; }
        public int value { get; set; }
        public Card card { get; set; }
        public string liability { get; set; }
    }

    public class OrderEvent
    {
        public string id { get; set; }
        public string fullCode { get; set; }
        public string code { get; set; }
        public DateTime createdAt { get; set; }
        public Metadata metadata { get; set; }
    }

    public class OrderStatusHistory
    {
        public string value { get; set; }
        public DateTime createdAt { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Payments
    {
        public List<PaymentsMethod> methods { get; set; }
    }

    public class Payout
    {
        public int amount { get; set; }
        public bool chargeback { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public bool compensate { get; set; }
        public string creditType { get; set; }
    }

    public class Prices
    {
        public int grossValue { get; set; }
        public int discount { get; set; }
        public int netValue { get; set; }
    }

    public class Refund
    {
        public int amount { get; set; }
        public string currency { get; set; }
        public int originalAmount { get; set; }
        public string category { get; set; }
        public int deadlineInMinutes { get; set; }
    }

    

    public class Sale
    {
        public string id { get; set; }
        public string shortId { get; set; }
        public DateTime createdAt { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string salesChannel { get; set; }
        public string currentStatus { get; set; }
        public Merchant merchant { get; set; }
        public SaleGrossValue saleGrossValue { get; set; }
        public Delivery delivery { get; set; }
        public Payments payments { get; set; }
        public List<OrderStatusHistory> orderStatusHistory { get; set; }
        public BillingSummary billingSummary { get; set; }
        public List<OrderEvent> orderEvents { get; set; }
    }

    public class SaleGrossValue
    {
        public int bag { get; set; }
        public int deliveryFee { get; set; }
        public int serviceFee { get; set; }
    }


}
