using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodyDelivery.Domain
{
    public  class OrderCreatedeliveryPoint
    {
        public string address { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string complement { get; set; }

        [JsonIgnore]
        public OrderCreatedeliveryPointCoordinates coordinates { get; set; }
    }

    public class OrderCreatedeliveryPointCoordinates
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
