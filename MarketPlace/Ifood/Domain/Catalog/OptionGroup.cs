using System.Collections.Generic;

namespace Ifood.Domain.Catalog
{
    public class OptionGroup
    {
        public string id { get; set; }
        public string externalCode { get; set; }
        public string name { get; set; }
        public string optionGroupType { get; set; }
        public int minQuantity { get; set; }
        public int maxQuantity { get; set; }
        public int sequence { get; set; }
        public string status { get; set; }
        public List<Option> options { get; set; }
    }
}
