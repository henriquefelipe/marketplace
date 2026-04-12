using System;
using System.Collections.Generic;

namespace Ifood.Domain.Catalog
{
    public class Catalogs
    {
        public string catalogId { get; set; }
        public string groupId { get; set; }
        public List<string> context { get; set; }
        public string status { get; set; }
        public string origin { get; set; }
        public DateTime? modifiedAt { get; set; }
    }
}
