namespace DeliveryDireto.Enum
{
    public class OrderStatusProcessing
    {
        public const string PEDIDO_EM_ESPERA = "WAI";
        public const string PEDIDO_APROVADO_EM_PRODUCAO = "APP";
        public const string SAIU_PARA_ENTREGA = "TRA";
        public const string PRODUZIDO_ENVIADO_CLIENTE = "PRO";
        public const string REJEITAR = "REJ";
        public const string CANCELAR = "ERR";
    }
}
