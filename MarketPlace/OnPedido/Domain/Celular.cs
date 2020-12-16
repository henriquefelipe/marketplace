using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Celular
    {
        [XmlElement]
        public string formatado { get; set; }
        [XmlElement]
        public string desformatado { get; set; }
    }
}
