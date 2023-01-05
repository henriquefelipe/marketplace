using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Domain
{
    public class orders
    {
        public string orderId { get; set; }
        public string orderCode { get; set; }
        public string typeOfPayment { get; set; }
        public decimal totalPrice { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
    }
}
