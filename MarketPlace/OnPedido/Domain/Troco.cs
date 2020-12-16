using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Troco
    {
        [XmlElement]
        public bool status { get; set; }
        [XmlElement]
        public decimal recebido { get; set; }
        [XmlElement]
        public decimal valor { get; set; }
    }
}
