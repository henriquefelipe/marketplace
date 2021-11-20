using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class payment
    {
        public bool prepaid { get; set; }  // Se foi pago
        public decimal pending { get; set; }
        public List<payment_methods> methods { get; set; }       
    }

    public class payment_methods
    {
        public decimal value { get; set; }
        public string currency { get; set; }
        public string method { get; set; }
        public string type { get; set; }
        public payment_methods_cash cash { get; set; }
        public bool prepaid { get; set; }
    }

    public class payment_methods_cash
    {
        public decimal changeFor { get; set; }
    }
 }
