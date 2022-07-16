using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Enum
{
    public class OrderStatus
    {
        public const string AVAILABLE = "AVAILABLE";
        public const string CONSUMING = "CONSUMING";
        public const string IN_PAYMENT = "IN_PAYMENT";
        public const string CLOSED = "CLOSED";
        public const string CANCELED = "CANCELED";        
    }
}
