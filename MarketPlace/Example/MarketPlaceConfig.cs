
namespace Example
{
    public class MarketPlaceConfig
    {
        public MarketPlaceConfigAnotaAi AnotaAi { get; set; }
        public MarketPlaceConfigAiqfome Aiqfome { get; set; }
        public MarketPlaceConfigAtivMob AtivMob { get; set; }
        public MarketPlaceConfigDeliveryApp DeliveryApp { get; set; }
        public MarketPlaceConfigDeliveryDireto DeliveryDireto { get; set; }
        public MarketPlaceConfigDeliveryDireto DeliveryVip { get; set; }
        public MarketPlaceConfigIfood Ifood { get; set; }
        public MarketPlaceConfigGloriaFood Gloria { get; set; }
        public MarketPlaceConfigGoomer Goomer { get; set; }
        public MarketPlaceConfigMeuCardapioAi MeuCardapioAi { get; set; }
        public MarketPlaceConfigLogaroo Logaroo { get; set; }
        public MarketPlaceConfigSuperMenu SuperMenu { get; set; }
        public MarketPlaceConfigRappi Rappi { get; set; }
        public MarketPlaceConfigOnPedido OnPedido { get; set; }
        public MarketPlaceConfigCinddi Cinddi { get; set; }
        public MarketPlacePedreiroDigital PedreiroDigital { get; set; }

        public MarketPlaceIDelivery IDelivery { get; set; }
        public MarketPlaceAccon Accon { get; set; }
        public MarketPlaceUberEats UberEats { get; set; }
        public MarketPlaceEpadoca Epadoca { get; set; }
        public MarketPlaceQueroDelivery QueroDelivery { get; set; }
        public MarketPlaceConfigAtivMob Iorion9 { get; set; }
        public MarketPlaceEpadoca Agilizone { get; set; }
        public MarketPlaceConfigAtivMob Wedo { get; set; }
        public MarketPlaceConfigGoomer Tray {  get; set; }
    }

    public class MarketPlaceConfigAnotaAi
    {
        public string Token { get; set; }
    }

    public class MarketPlaceConfigAtivMob
    {
        public string Token { get; set; }
        public string Url { get; set; }
        public string MerchantId { get; set; }
        public string Usuario { get; set; }

        public string Senha { get; set; }
    }


    public class MarketPlaceConfigDeliveryApp
    {
        public string Token { get; set; }
    }

    public class MarketPlaceConfigDeliveryDireto
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }

    public class MarketPlaceConfigIfood
    {
        public string Client_ID { get; set; }
        public string Client_SECRET { get; set; }

        public string MerchantId { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
        public string AuthorizationCode { get; set; }
        public string AuthorizationCodeVerifier { get; set; }
    }

    public class MarketPlaceConfigGloriaFood
    {
        public string Token { get; set; }       
    }

    public class MarketPlaceConfigGoomer
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }
        public string Client_SECRET { get; set; }
        public string Client_ID { get; set; }
        public string Url { get; set; }
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

    public class MarketPlacePedreiroDigital
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }
        public string Url { get; set; }
    }

    public class MarketPlaceIDelivery
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }
        public string Url { get; set; }
    }

    public class MarketPlaceAccon
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Rede { get; set; }
    }

    public class MarketPlaceUberEats
    {
        public string Client_SECRET { get; set; }
        public string Client_ID { get; set; }
        public string MerchantId { get; set; }
    }

    public class MarketPlaceConfigAiqfome
    {
        public string Token { get; set; }
        public string Url { get; set; }
        public string MerchantId { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }

    public class MarketPlaceEpadoca
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Url { get; set; }
        public string MerchantId { get; set; }
    }

    public class MarketPlaceQueroDelivery
    {
        public string Token { get; set; }
        public string PlaceId { get; set; }
    }

}
