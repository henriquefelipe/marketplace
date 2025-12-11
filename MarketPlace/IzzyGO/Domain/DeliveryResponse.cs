using System;
using System.Collections.Generic;
using System.Text;

namespace IzzyGO.Domain
{
    public class DeliveryResponse
    {
        public bool Success { get; set; }
        public DeliveryData Data { get; set; }
        public string Error { get; set; }
    }
}
