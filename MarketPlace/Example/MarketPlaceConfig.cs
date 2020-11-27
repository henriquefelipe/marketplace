
namespace Example
{
    public class MarketPlaceConfig
    {
        public MarketPlaceConfigDeliveryApp DeliveryApp { get; set; }
        public MarketPlaceConfigIfood Ifood { get; set; }
        public MarketPlaceConfigGloriaFood Gloria { get; set; }
        public MarketPlaceConfigMeuPedidoAi MeuPedidoAi { get; set; }
        public MarketPlaceConfigLogaroo Logaroo { get; set; }
        public MarketPlaceConfigSuperMenu SuperMenu { get; set; }
    }

    public class MarketPlaceConfigDeliveryApp
    {
        public string Token { get; set; }
    }

    public class MarketPlaceConfigIfood
    {
        public string Client_ID { get; set; }
        public string Client_SECRET { get; set; }

        public string MerchantId { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }

    public class MarketPlaceConfigGloriaFood
    {
        public string Token { get; set; }       
    }

    public class MarketPlaceConfigMeuPedidoAi
    {
        public string Client_ID { get; set; }
        public string Client_SECRET { get; set; }
    }

    public class MarketPlaceConfigLogaroo
    {
        public string Client_ID { get; set; }
        public string Client_SECRET { get; set; }

        public string MerchantId { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }

    public class MarketPlaceConfigSuperMenu
    {
        public string Token { get; set; }
    }
}
