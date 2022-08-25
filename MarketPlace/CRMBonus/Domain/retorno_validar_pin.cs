using System;
using System.Collections.Generic;
using System.Text;

namespace CRMBonus.Domain
{
    public class retorno_validar_pin
    {
        public int loja_id { get; set; }
        public int customer_id { get; set; }
        public bool valid_pin { get; set; }
        public bool pin_master { get; set; }
        public bool can_used_pin_master { get; set; }

        public string msg { get; set; }
    }
}
