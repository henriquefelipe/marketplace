using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Utils
{
    public static class Constants
    {
        public const string URL_BASE = "https://pos.globalfoodsoft.com/pos/";

        /// <summary>
        /// Utilizado quando é pra utilizar local
        /// https://github.com/GlobalFood/integration_docs/blob/master/accepted_orders/version_1/ORDER.md
        /// </summary>
        public const string POOL_LOCAL_SYSTEM = "order/pop";

        /// <summary>
        /// Utilizado para buscar o cardápio
        /// https://github.com/GlobalFood/integration_docs/blob/master/fetch_menu/README.md
        /// </summary>
        public const string MENU = "menu";
    }
}
