using System.Collections.Generic;

namespace Ifood.Domain.Catalog
{
    public class CatalogItemsResponse
    {
        public string categoryId { get; set; }
        public List<CatalogItem> items { get; set; }
    }

    public class CatalogItem
    {
        public string id { get; set; }
        public string externalCode { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ean { get; set; }
        public string additionalInformation { get; set; }
        public string logoUrl { get; set; }
        public string imageUrl { get; set; }
        public string imagePath { get; set; }
        public string unit { get; set; }
        public decimal quantity { get; set; }
        public string serving { get; set; }
        public string status { get; set; }
        public bool isAlcoholic { get; set; }
        public int sequence { get; set; }
        public int productionTime { get; set; }
        public ItemPrice price { get; set; }
        public List<string> dietaryRestrictions { get; set; }
        public List<string> tags { get; set; }
        public List<OptionGroup> optionGroups { get; set; }
    }
}
