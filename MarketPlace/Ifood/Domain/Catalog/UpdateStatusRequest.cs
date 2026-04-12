namespace Ifood.Domain.Catalog
{
    public class UpdateStatusRequest
    {
        public string status { get; set; }
    }

    public class UpdatePriceRequest
    {
        public ItemPrice price { get; set; }
    }
}
