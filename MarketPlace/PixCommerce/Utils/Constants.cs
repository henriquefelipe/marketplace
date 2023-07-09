using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixCommerce.Utils
{
    public static class Constants
    {
        public const string URL_BASE_PRODUCAO = "https://apis.pixcommerce.com.br:3647/";


        public const string URL_ORDERS = "vendas/polling";
        public const string URL_ORDER = "vendas/izzyway";
        public const string URL_ORDER_CONFIRM = "vendas/izzyway/confirm/";
        public const string URL_ORDER_CHANGE = "vendas/change/";
        public const string URL_ORDER_CANCEL = "vendas/cancel/";
    }
}
