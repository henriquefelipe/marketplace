using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class orderCustomer
    {
        public string id {  get; set; }
        public string name { get; set; }
        public orderCustomerPhone phone { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; }
        public int ordersCountOnMerchant {  get; set; }
    }

    public class orderCustomerPhone
    {
        public string number { get; set; }
    }
}
