using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;

namespace Plug4Sales.Domain
{
    public class otherFees
    {
        public otherFees()
        {
            types = "DELIVERY_FEE";
            name = "Frete";
        }

        public string name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string types { get; set; }

        public otherFees_price price { get; set; }
    }

    public class otherFees_price
    {
        public otherFees_price()
        {
            currency = "BRL";
        }

        public decimal value { get; set; }
        public string currency { get; set; }
    }
}
