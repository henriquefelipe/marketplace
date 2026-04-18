using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ifood.Domain.Catalog
{
    public class OptionGroup
    {
        public string id { get; set; }
        public string externalCode { get; set; }
        public string name { get; set; }
        public string optionGroupType { get; set; }
        [JsonProperty("min")]
        public int minQuantity { get; set; }
        [JsonProperty("max")]
        public int maxQuantity { get; set; }
        public int sequence { get; set; }
        public string status { get; set; }
        public List<Option> options { get; set; }
    }
}
