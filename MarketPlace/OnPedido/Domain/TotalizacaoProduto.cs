using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class TotalizacaoProduto
    {
        [XmlElement]
        public decimal opcoes { get; set; }
        [XmlElement]
        public decimal produto { get; set; }
        [XmlElement]
        public decimal total { get; set; }
    }
}
