using System;
using System.Collections.Generic;
using System.Text;

namespace Woocommerce.Enum
{
    public class order_status
    {
        public const string PROCESSING = "processing";
        public const string ANY = "any";
        public const string PENDING = "pending";
        public const string ON_HOLD = "on-hold";
        public const string COMPLETED = "completed";
        public const string CANCELLED = "cancelled";
        public const string REFUNDED = "refunded";
        public const string FAILED = "failed";        
        public const string TRASH = "trash";
    }
}
