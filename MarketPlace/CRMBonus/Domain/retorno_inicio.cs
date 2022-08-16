using System;
using System.Collections.Generic;
using System.Text;

namespace CRMBonus.Domain
{
    public class retorno_inicio
    {
        public int loja_id { get; set; }
        public int customer_id { get; set; }
        public bool solicita_pin { get; set; }
        public string sms { get; set; }
    }
}
