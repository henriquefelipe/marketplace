using System;
using System.Collections.Generic;
using System.Text;

namespace SelfBuyMe.Domain
{
    public class result<TResult>
    { 
        public bool status { get; set; }
        public string message { get; set; }
        public TResult data { get; set; }
    }
}
