using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegustaAi.Utils
{
    public static class Constants
    {
        public const string URL_GET_ORDERS = "/api/delivery/getorders";
        public const string URL_CHANGE_STATUS = "/api/delivery/changestatus";
        public const string URL_CANCELA_PEDIDO = "/api/delivery/cancelaPedido";
        public const string URL_SEND_TO_MOTOBOY_SERVICE = "/api/delivery/sendToMotoboyService";

        public const string URL_REGISTRA_PONTOS = "/api/registraPontos";
        public const string URL_RESGASTA_PREMIO = "/api/resgataPremio";
        public const string URL_CRIA_CADASTRO = "/api/criaCadastro";
        public const string URL_ATUALIZA_CADASTRO = "/api/atualizaCadastro";
        public const string URL_LISTA_USUARIOS = "/api/listaUsuarios";
        public const string URL_RESUMO_USUARIO = "/api/resumoUsuario";
        public const string URL_CONSULTA_PREMIOS = "/api/consultaPremios";
        public const string URL_TOKEN_INFO = "/api/tokenInfo";
        public const string URL_AUTH_LOGIN = "/api/auth/login";

        public const string URL_GET_ORDERS_MESA = "/api/cardapiodigital/getorders";
        public const string URL_FECHAR_MESA = "/api/cardapiodigital/fechaMesa";
        public const string URL_GET_NOTIFICATIONS_MESA = "/api/cardapiodigital/getNotifications";
        public const string URL_CHANGE_STATUS_MESA = "/api/cardapiodigital/changestatus";
        public const string URL_DISMISS_NOTIFICATION_MESA = "/api/cardapiodigital/dismissNotification";
    }
}
