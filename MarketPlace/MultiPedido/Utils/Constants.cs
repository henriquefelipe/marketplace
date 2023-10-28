using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPedido.Utils
{
    public static class Constants
    {
        public const string URL_BASE_PRODUCAO = "https://2bhghu4v3iluwl77hwcmwkbije0rroef.lambda-url.us-east-1.on.aws/";

        public const string URL_POLL = "poll";
        public const string URL_ACKNOWLEDGE = "acknowledge?orderID=";


        public const string URL_BASE_PRODUCAO_PADRAO = "https://api.multipedidos.com.br/";

        public const string URL_LOGIN = "integration/auth/login";        
    }
}
