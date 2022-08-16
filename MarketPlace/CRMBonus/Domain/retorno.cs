using System;
using System.Collections.Generic;
using System.Text;

namespace CRMBonus.Domain
{
    public class retorno<TResult> : retorno_simple
    {        
        public TResult data { get; set; }

    }

    public class retorno_simple
    {
        public bool status { get; set; }
        public string message { get; set; }
    }
}
