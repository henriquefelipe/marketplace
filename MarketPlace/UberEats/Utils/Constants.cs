using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Utils
{
    public static class Constants
    {

        public const string URL_TOKEN = "https://login.uber.com/oauth/v2/token";
        public const string URL_ORDER = "https://api.uber.com/v2/eats/order/";
        public const string URL_CREATE_ORDERS_CREATED = "https://api.uber.com/v1/eats/stores/"; // "/created-orders?limit=5"        
        public const string URL_ORDERS = "https://api.uber.com/v1/eats/orders/";

        //public const string URL_CREATE_ORDERS_CANCELED = "https://api.uber.com/v1/eats/stores/{{eats_store_id}}/canceled-orders?limit=5";
        //public const string URL_ORDER_CANCEL = "https://api.uber.com/v1/eats/orders/{{order_id}}/cancel";
        //public const string URL_ORDER_DANY = "https://api.uber.com/v1/eats/orders/{{order_id}}/deny_pos_order";


        public const string SCOPE_EATS_ORDER = "eats.order"; //Aceite/Deny do pedido
        public const string SCOPE_EATS_STORE_ORDERS_READ = "eats.store.orders.read"; // Leitura dos detalhes do pedido / Pegar lista dos últimos pedidos aceitos ou cancelados
        public const string SCOPE_EATS_STORE_ORDERS_CANCEL = "eats.store.orders.cancel"; //Cancelamento dos pedidos
    }
}
