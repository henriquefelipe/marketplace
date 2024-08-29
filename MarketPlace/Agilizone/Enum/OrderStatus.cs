using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Agilizone.Enum
{
    public static class OrderStatus
    {
        public const string PREPARED = "PREPARED";
        public const string COMPLETED = "COMPLETED";
        public const string CANCELED = "CANCELED";
        public const string ASSIGNED = "ASSIGNED";
        public const string COLLECTED = "COLLECTED"; //saiu para entrega
    }
}
