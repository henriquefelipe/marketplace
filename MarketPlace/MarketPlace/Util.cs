using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace
{
    public static class Util
    {
        public static string InnerException(Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            return ex.Message;
        }
    }    
}
