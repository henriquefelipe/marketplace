using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Enum
{
    public class EventStatus
    {
        public const string CONSUMING = "CONSUMING";
        public const string NEW = "NEW";
        public const string PENDING = "PENDING";
        public const string BLOCK = "BLOCK";
        public const string UNLOCK = "UNLOCK";
        public const string IN_PAYMENT = "IN_PAYMENT";
        public const string CHANGE_TABLE = "CHANGE_TABLE";
        public const string CANCELED = "CANCELED";
    }
}
