using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Pagamento
    {
        [XmlElement]
        public string id { get; set; }
        [XmlElement]
        public string forma { get; set; }

    }
}
