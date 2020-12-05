﻿
namespace Example
{
    public class MarketPlaceConfig
    {
        public MarketPlaceConfig()
        {
            this.AnotaAi = new MarketPlaceConfigAnotaAi();
            this.DeliveryApp = new MarketPlaceConfigDeliveryApp();
            this.Ifood = new MarketPlaceConfigIfood();
            this.Gloria = new MarketPlaceConfigGloriaFood();
            this.MeuCardapioAi = new MarketPlaceConfigMeuCardapioAi();
            this.Logaroo = new MarketPlaceConfigLogaroo();
            this.SuperMenu = new MarketPlaceConfigSuperMenu();
        }
        public MarketPlaceConfigAnotaAi AnotaAi { get; set; }
        public MarketPlaceConfigDeliveryApp DeliveryApp { get; set; }
        public MarketPlaceConfigIfood Ifood { get; set; }
        public MarketPlaceConfigGloriaFood Gloria { get; set; }
        public MarketPlaceConfigMeuCardapioAi MeuCardapioAi { get; set; }
        public MarketPlaceConfigLogaroo Logaroo { get; set; }
        public MarketPlaceConfigSuperMenu SuperMenu { get; set; }
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
}
