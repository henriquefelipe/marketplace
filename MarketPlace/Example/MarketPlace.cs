
namespace Example
{
    public class MarketPlace
    {
        public Ifood Ifood { get; set; }
    }

    public class Ifood
    {
        public string Client_ID { get; set; }
        public string Client_SECRET { get; set; }

        public string MerchantId { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }
}
