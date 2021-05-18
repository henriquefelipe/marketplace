using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDelivery.Domain
{
    public class payment
    {
        public string name { get; set; }
        public string code { get; set; }
        public decimal value { get; set; }
        public bool prepaid { get; set; }  // Se foi pago
        public string issuer { get; set; }
        public decimal changeFor { get; set; }
    }
}
