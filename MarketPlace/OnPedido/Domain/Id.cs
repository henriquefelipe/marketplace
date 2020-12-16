using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Id
    {
        [XmlElement]
        public long pedido { get; set; }
        [XmlElement]
        public long cliente { get; set; }
    }
}
