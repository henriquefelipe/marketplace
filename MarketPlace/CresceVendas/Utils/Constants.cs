using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CresceVendas.Utils
{
    public static class Constants
    {
        public const string URL_BASE_HOMOLOGACAO = "https://demo.apicrescevendas.com/";
        public const string URL_BASE_PRODUCAO = "https://www.apicrescevendas.com/";


        public const string URL_COMPRA = "admin/api/v2/shops";
        public const string URL_CONSULTAR_SALDO = "admin/api/v2/shops/check_balance";
        public const string URL_CANCELAR = "admin/api/v2/shops/cancel";
        public const string URL_CONSULTAR_USUARIO = "admin/api/v2/users/get";
        public const string URL_DIARIO_TOTAL_COMPRAS = "admin/api/v2/shops/overall";
        public const string URL_DESCONTOS_LOJA = "admin/reports/v2/discount_stores";
        public const string URL_PRE_CADASTRO = "admin/api/v2/users/pre_registration";        
    }
}
