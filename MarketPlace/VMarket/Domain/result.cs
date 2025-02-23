using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VMarket.Domain
{
    public class resultBase
    {
        public int current_page { get; set; }        
    }

    public class result<TResult> : resultBase
    {
        public TResult data { get; set; }
    }
}
