using Newtonsoft.Json;

namespace Ifood.Domain.Catalog
{
    public class Option
    {
        public string id { get; set; }
        public string externalCode { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ean { get; set; }
        public string logoUrl { get; set; }
        public ItemPrice price { get; set; }
        [JsonProperty("max")]
        public int maxQuantity { get; set; }
        public int sequence { get; set; }
        public string status { get; set; }
    }
}
