using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Americanas.Domain
{
    public class retorno_status
    {
        public string message { get; set; }
        public retorno_status_order order { get; set; }
    }

    public class retorno_status_order
    {
        public int id { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public int preparation_time { get; set; }
    }
}
