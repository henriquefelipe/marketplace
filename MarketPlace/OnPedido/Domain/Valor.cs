using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Valor
    {
        [XmlElement]
        public decimal unid { get; set; }
        [XmlElement]
        public decimal total { get; set; }
    }
}
