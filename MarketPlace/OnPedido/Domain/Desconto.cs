using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Desconto
    {
        [XmlElement]
        public bool status { get; set; }
        [XmlElement]
        public decimal percentual { get; set; }
        [XmlElement]
        public decimal valor { get; set; }
    }
}
