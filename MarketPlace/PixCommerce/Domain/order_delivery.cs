using System;
using System.Collections.Generic;
using System.Text;

namespace PixCommerce.Domain
{
    public class order_delivery
    {
        public string mode { get; set; }
        public string deliveredBy { get; set; }
        public string deliveryDateTime { get; set; }
        public order_delivery_deliveryAddress deliveryAddress { get; set; }
    }

    public class order_delivery_deliveryAddress
    {
        public string reference { get; set; }
        public string country { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string neighborhood { get; set; }
        public string state { get; set; }
        public string complement { get; set; }
        public string formattedAddress { get; set; }
        public order_delivery_deliveryAddress_coordinates coordinates { get; set; }
    }

    public class order_delivery_deliveryAddress_coordinates
    {

    }
}
