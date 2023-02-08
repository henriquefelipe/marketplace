using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Domain
{
    public class order
    {
        public decimal? id { get; set; }
        public string clientName { get; set; }
        public string createdAt { get; set; }
        public string canceledAt { get; set; }
        public decimal? amount { get; set; }
        public decimal? change { get; set; }
        public string telephone { get; set; }
        public string zipCode { get; set; }
        public string address { get; set; }
        public string addressNumber { get; set; }
        public string addressComplement { get; set; }
        public string referencePoint { get; set; }
        public string note { get; set; }
        public string deliveryAt { get; set; }
        public string delivererName { get; set; }
        public string status { get; set; }
        public bool takeAway { get; set; }
        public string socialMediaUsuerId { get; set; }
        public string couponCode { get; set; }
        public string couponType { get; set; }
        public decimal? couponValue { get; set; }
        public bool printed { get; set; }
        public decimal? deliveryFee { get; set; }
        public string neighborhoodName { get; set; }
        public string scheduledTo { get; set; }
        public string authorizationCode { get; set; }
        public string schedulingEnd { get; set; }
        public string tableNumber { get; set; }
        public string cityName { get; set; }
        public string stateShortform { get; set; }
        public decimal? waiterPercentage { get; set; }
        public decimal? balconyDiscount { get; set; }
        public string countryName { get; set; }
        public string paymentMethod { get; set; }
        public string currency { get; set; }
        public decimal? additionalFees { get; set; }
        public decimal? subTotal { get; set; }
        public string displayId { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public decimal? storeId { get; set; }
        public string storeName { get; set; }
        public string logisticStatus { get; set; }
        public List<orderProducts> orderProducts { get; set; }
    }
}
