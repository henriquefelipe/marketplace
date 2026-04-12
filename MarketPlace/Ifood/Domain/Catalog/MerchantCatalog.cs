using System.Collections.Generic;

namespace Ifood.Domain.Catalog
{
    public class MerchantCatalog
    {
        public MerchantCatalog()
        {
            catalogs = new List<CatalogFull>();
        }

        public string merchantId { get; set; }
        public List<CatalogFull> catalogs { get; set; }
    }

    public class CatalogFull
    {
        public CatalogFull()
        {
            groups = new List<Categories>();
            items = new List<CatalogItem>();
            optionGroups = new List<OptionGroup>();
        }

        public Catalogs catalog { get; set; }
        public List<Categories> groups { get; set; }
        public List<CatalogItem> items { get; set; }
        public List<OptionGroup> optionGroups { get; set; }
        public UnsellableItems unsellableItems { get; set; }
    }
}
