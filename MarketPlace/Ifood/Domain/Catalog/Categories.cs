using System;
using System.Collections.Generic;

namespace Ifood.Domain.Catalog
{
    public class Categories
    {
        public string id { get; set; }
        public string name { get; set; }
        public string externalCode { get; set; }
        public string template { get; set; }
        public string status { get; set; }
        public int sequence { get; set; }
        public List<CatalogItem> items { get; set; }
    }
}
