﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class orderDelivery
    {
        public string deliveredBy { get; set; }
        public string estimatedDeliveryDateTime { get; set; }
        public orderDeliveryAddress deliveryAddress { get; set; }
    }

    public class orderDeliveryAddress
    {
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string postalCode { get; set; }
        public string formattedAddress { get; set; }
        public orderDeliveryAddressCoordinates coordinates { get; set; }
    }

    public class orderDeliveryAddressCoordinates
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
