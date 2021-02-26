using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class order_payment
    {
        public string codFormaPagto { get; set; }
        public string descricaoFormaPagto { get; set; }
        public decimal valor { get; set; }
    }
}
