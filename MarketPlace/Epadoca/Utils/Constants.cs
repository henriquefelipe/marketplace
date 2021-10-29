using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Utils
{
    public static class Constants
    {
        public const string URL_BASE = "https://iapi.epadoca.com/";

        public const string URL_BASE_DES = "http://dev.api.epadoca.com/";

        public const string URL_TOKEN = "token";
        public const string URL_MANAGER_PADARIA_GET = "manager/padaria/Get";
        public const string URL_MANAGER_PEDIDO_GET = "manager/pedido/Get";
        public const string URL_MANAGER_PEDIDO_ABERTO = "manager/pedido/completo/aberto";
        public const string URL_MANAGER_PEDIDO_PREPARAR_PEDIDO = "manager/pedido/PrepararPedido";
        public const string URL_MANAGER_PEDIDO_COMPLETO = "manager/pedido/completo/";
        public const string URL_MANAGER_PEDIDO_DETALHE = "manager/pedido/Detalhe/";
        public const string URL_MANAGER_PEDIDO_PRODUTOS = "manager/pedido/produtos/";
        public const string URL_MANAGER_PEDIDO_ENTREGARPEDIDO = "manager/pedido/EntregarPedido";
        public const string URL_MANAGER_PEDIDO_FINALIZAR_PEDIDO = "manager/pedido/FinalizarPedido";
        public const string URL_MANAGER_PEDIDO_PRONTO = "manager/pedido/pronto";
        public const string URL_MANAGER_PEDIDO_NOTIFICAR_ATRASO = "manager/pedido/NotificarAtraso";        
    }
}
