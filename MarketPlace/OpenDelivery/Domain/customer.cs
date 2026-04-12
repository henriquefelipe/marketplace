using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Domain
{
    public class customer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string documentNumber { get; set; } //CPF do cliente
        public customer_phone phone { get; set; }
        public string email { get; set; }
        public decimal? ordersCountOnMerchant { get; set; }
    }

    public class customer_phone
    {
        public string number { get; set; }
        public string extension { get; set; }        
    }
}
