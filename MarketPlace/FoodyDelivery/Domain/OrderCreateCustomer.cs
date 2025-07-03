using System;
using System.Collections.Generic;
using System.Text;

namespace FoodyDelivery.Domain
{
    public class OrderCreateCustomer
    {
        public string customerPhone { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
    }
}
