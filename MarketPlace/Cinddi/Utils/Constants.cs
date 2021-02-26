using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinddi.Utils
{
    public static class Constants
    {
        public const string URL = "https://cinndi.azurewebsites.net/api/";

        public const string URL_ORDERS = "consulta_pedidos.php?chave=";
        public const string URL_ORDER = "consulta_xml.php?chave=";
        public const string URL_ORDER_CONCLUSION = "encerrar_pedido.php?chave=";
        public const string URL_ORDER_STATUS = "status_pedido.php?status=";
    }
}
