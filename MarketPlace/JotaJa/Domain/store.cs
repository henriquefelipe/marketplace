using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Domain
{
    public class store
    {
        public int id { get; set; }
        public string corporateName { get; set; }
        public string tradeName { get; set; }
        public string zipCode { get; set; }
        public string address { get; set; }
        public string addressNumber { get; set; }
        public string addressComplement { get; set; }
        public string mobile { get; set; }
        public string telephone { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string slug { get; set; }
        public string logo { get; set; }
        public bool isActive { get; set; }
        public string documentNumber { get; set; }
        public string neighborhoodName { get; set; }
        public bool isFranchisor { get; set; }
        public bool useBalconyOrderMode { get; set; }
        public bool useFoodTruckMode { get; set; }
        public bool useSalonServiceMode { get; set; }
        public bool useFastDelivery { get; set; }
        public bool useScheduling { get; set; }
        public int? minimumSchedulingTime { get; set; }
        public int? freight { get; set; }
        public bool useSchedulingOnly { get; set; }
        public string maximumSchedulingTime { get; set; }
        public bool useOnlinePayment { get; set; }
        public int deliveryFee { get; set; }
        public string takeAwayPreparationTime { get; set; }
        public int takeawayMinimumAmount { get; set; }
        public bool useTableService { get; set; }
        public int? maximunTableQuantity { get; set; }
        public string pixCode { get; set; }
        public bool useOperationTime { get; set; }
        public string minimumInventory { get; set; }
        public int waiterPercentage { get; set; }
        public int preparationTimer { get; set; }
    }
}
