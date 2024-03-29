﻿using System;
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
        public const string TABLE_PAID = "TABLE_PAID"; // Pagamento
        public const string PAID = "PAID"; // Pagamento
        public const string NEW_ADVANCE = "NEW_ADVANCE"; // Adiantamento
        public const string CLOSED = "CLOSED";
    }
}
