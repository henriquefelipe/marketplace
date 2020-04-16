using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace
{
    public class GenericSimpleResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Json { get; set; }
    }

    public class GenericResult<TResult> : GenericSimpleResult
    {
        public TResult Result { get; set; }
    }
}
