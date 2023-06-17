using System;
using System.Collections.Generic;
using System.Text;

namespace PixCommerce.Domain
{
    public class order_customer
    {
        public string documentNumber { get; set; }
        public string name { get; set; }
        public int ordersCountOnMerchant { get; set; }
        public string segmentation { get; set; }
        public string id { get; set; }
        public order_customer_phone phone { get; set; }
    }

    public class order_customer_phone
    {
        public string number { get; set; }
        public string localizer { get; set; }
        public string localizerExpiration { get; set; }
    }
}
