namespace OnPedido.Utils
{
    public static class Constants
    {
        public const string URL = "https://api.onpedido.com.br/xml3?token=";
        
        public const string URL_ORDERS = "&acao=pedidos";
        public const string URL_ORDER = "&acao=pedido&idpedido=";
        public const string URL_STATUS = "&acao=status&statusPedido=";
    }
}
