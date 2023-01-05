using System;
using System.Collections.Generic;
using System.Text;

namespace CRMBonus.Domain
{
    public class retorno_cancelar_bonus
    {
        public bool status { get; set; }
        public retorno_cancelar_bonus_message message { get; set; }
        public retorno_cancelar_bonus_data data { get; set; }        
    }

    public class retorno_cancelar_bonus_message
    {
        public string msg { get; set; }
    }

    public class retorno_cancelar_bonus_data
    {
        public string msg { get; set; }
    }
 }
