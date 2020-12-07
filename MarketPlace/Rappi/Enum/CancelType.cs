using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Enum
{
    public class CancelType
    {
        public const string ITEM_WRONG_PRICE = "ITEM_WRONG_PRICE";
        public const string ITEM_NOT_FOUND = "ITEM_NOT_FOUND";
        public const string ITEM_OUT_OF_STOCK = "ITEM_OUT_OF_STOCK";
        public const string ORDER_MISSING_INFORMATION = "ORDER_MISSING_INFORMATION";
        public const string ORDER_MISSING_ADDRESS_INFORMATION = "ORDER_MISSING_ADDRESS_INFORMATION";
        public const string ORDER_TOTAL_INCORRECT = "ORDER_TOTAL_INCORRECT";
    }
}
