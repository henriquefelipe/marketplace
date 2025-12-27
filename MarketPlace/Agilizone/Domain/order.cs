using Newtonsoft.Json;
using System.Collections.Generic;

namespace Agilizone.Domain
{
    public class order
    {
        public order_address address { get; set; }
        public order_client client { get; set; }
        public string details { get; set; }
        public string number { get; set; }
        public string identifier { get; set; }
        public string paymentType { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal deliverymanFee { get; set; }
        public decimal amount { get; set; }
        public bool isPrepaid { get; set; }
        public string originPlatform { get; set; }
        public string observations { get; set; }
        public string externalId { get; set; }
        public string preparationTime { get; set; }
        public string orderTiming { get; set; }
        public string scheduledPreparationTime { get; set; }
        public order_paymentExtraInfo paymentExtraInfo { get; set; }
        public order_ifood_data ifoodData { get; set; }

    }

    public class order_address
    {
        public string city { get; set; }
        public string complement { get; set; }
        public order_address_coordinates coordinates { get; set; }
        public string country { get; set; }
        public string number { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string neighborhood { get; set; }
        public string postcode { get; set; }
        public string reference { get; set; }
    }

    public class order_address_coordinates
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }

    public class order_client
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    //"history": [
    //        {
    //            "timestamp": "2024-04-21T00:00:26.974Z",
    //            "status": "PREPARING",
    //            "user": {
    //                "id": "ff11f50b-b6d1-4bd4-9075-07783dc09b50",
    //                "name": "integration-user"
    //            },
    //            "deliveryman": null,
    //            "description": null
    //        }
    //    ],

    public class order_paymentExtraInfo
    {
        public order_paymentExtraInfo()
        {
            discountCoupons = new List<order_paymentExtraInfo_discountCoupons>();
        }

        public string cardBrand { get; set; }

        public decimal changeFor { get; set; }
        public List<order_paymentExtraInfo_discountCoupons> discountCoupons { get; set; }
    }

    public class order_paymentExtraInfo_discountCoupons
    {
        public string sponsor { get; set; }
        public decimal value { get; set; }
    }

    public class order_ifood_data
    {
        public order_ifood_data()
        {
            salesChannel = "IFOOD";
        }

        public string localizer { get; set; }
        public string salesChannel { get; set; }
        public string id { get; set; }
        public string merchantName { get; set; }        
    }
}
