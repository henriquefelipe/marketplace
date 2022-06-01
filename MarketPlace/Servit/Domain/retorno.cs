using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class retorno
    {
        public bool success { get; set; }
        public string title { get; set; }
        public string message { get; set; }        
    }

    public class retornoGeneric<TResult> : retorno
    {
        public TResult data { get; set; }
    }

}
