using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class voucher
    {
        public decimal voucher_discount { get; set; }
        public string voucher_code { get; set; }
        public string voucher_brinde { get; set; }
        public string voucher_brinde_ref { get; set; }
    }
}
