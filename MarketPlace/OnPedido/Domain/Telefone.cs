using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Telefone
    {
        [XmlElement]
        public bool status { get; set; }
        [XmlElement]
        public bool formatado { get; set; }
        [XmlElement]
        public bool desformatado { get; set; }
    }
}
