using System;
using System.Collections.Generic;
using System.Text;

namespace QueroDelivery.Enum
{
    public class CancellationCodes
    {
        public const string SYSTEMIC_ISSUES = "SYSTEMIC_ISSUES";
        public const string DUPLICATE_APPLICATION = "DUPLICATE_APPLICATION";
        public const string UNAVAILABLE_ITEM = "UNAVAILABLE_ITEM";
        public const string RESTAURANT_WITHOUT_DELIVERY_MAN = "RESTAURANT_WITHOUT_DELIVERY_MAN";
        public const string OUTDATED_MENU = "OUTDATED_MENU";
        public const string ORDER_OUTSIDE_THE_DELIVERY_AREA = "ORDER_OUTSIDE_THE_DELIVERY_AREA";
        public const string BLOCKED_CUSTOMER = "BLOCKED_CUSTOMER";
        public const string OUTSIDE_DELIVERY_HOURS = "OUTSIDE_DELIVERY_HOURS";
        public const string INTERNAL_DIFFICULTIES_OF_THE_RESTAURANT = "INTERNAL_DIFFICULTIES_OF_THE_RESTAURANT";
        public const string RISK_AREA = "RISK_AREA";
    }
}