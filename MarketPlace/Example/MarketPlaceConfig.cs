
namespace Example
{
    public class MarketPlaceConfig
    {
        public MarketPlaceConfigAnotaAi AnotaAi { get; set; }
        public MarketPlaceConfigDeliveryApp DeliveryApp { get; set; }
        public MarketPlaceConfigIfood Ifood { get; set; }
        public MarketPlaceConfigGloriaFood Gloria { get; set; }
        public MarketPlaceConfigMeuCardapioAi MeuCardapioAi { get; set; }
        public MarketPlaceConfigLogaroo Logaroo { get; set; }
        public MarketPlaceConfigSuperMenu SuperMenu { get; set; }
        public MarketPlaceConfigRappi Rappi { get; set; }
        public MarketPlaceConfigOnPedido OnPedido { get; set; }
        public MarketPlaceConfigCinddi Cinddi { get; set; }
    }

    public class MarketPlaceConfigAnotaAi
    {
        public string Token { get; set; }
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

    public class MarketPlaceConfigMeuCardapioAi
    {
        public string Client_ID { get; set; }
        public string Client_SECRET { get; set; }
        public string Url { get; set; }
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

    public class MarketPlaceConfigRappi
    {
        public string Client_ID { get; set; }
        public string Client_SECRET { get; set; }
        public string Url { get; set; }
    }

    public class MarketPlaceConfigOnPedido
    {
        public string Token { get; set; }
    }

    public class MarketPlaceConfigCinddi
    {
        public string Token { get; set; }
    }
}
