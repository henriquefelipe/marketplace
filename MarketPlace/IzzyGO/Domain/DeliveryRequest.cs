using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class DeliveryRequest
    {
        public string OrderId { get; set; }
        public string OrderDisplayId { get; set; }
        public MerchantInfo Merchant { get; set; }
        public CustomerInfo Customer { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public PickupAddress PickupAddress { get; set; }
        public VehicleInfo Vehicle { get; set; }
        public PackageInfo Package { get; set; }
        public NotificationFlags Notifications { get; set; }
        public OrderPricing Pricing { get; set; }
        public List<PaymentInfo> Payments { get; set; }
        public List<OrderItem> Items { get; set; }
        public string SpecialInstructions { get; set; }
        public DateTime? PreparationStartDatetime { get; set; }
        public string SourceAppId { get; set; }
        public string SourceOrderId { get; set; }
        public int? PickupLimit { get; set; }
        public int? DeliveryLimit { get; set; }
        public bool? CanCombine { get; set; }
        public bool? ReturnToMerchant { get; set; }
        public bool? ConfirmationCodeRequired { get; set; }
    }
}
