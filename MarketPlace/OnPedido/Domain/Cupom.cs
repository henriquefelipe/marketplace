using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Cupom
    {
        [XmlElement]
        public bool status { get; set; }
        [XmlElement]
        public decimal desconto { get; set; }
        [XmlElement]
        public string cupom { get; set; }
    }
}
