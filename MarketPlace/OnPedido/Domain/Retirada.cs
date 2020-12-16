using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Retirada
    {
        [XmlElement]
        public bool status { get; set; }
    }
}
