using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class TotalizacaoPedido
    {
        [XmlElement(Type = typeof(Cupom))]
        public Cupom cupom { get; set; }
        [XmlElement]
        public decimal taxa { get; set; }
        [XmlElement(Type = typeof(Retirada))]
        public Retirada retirada { get; set; }
        [XmlElement(Type = typeof(Pagamento))]
        public Pagamento pagamento { get; set; }
        [XmlElement(Type = typeof(Troco))]
        public Troco troco { get; set; }
        [XmlElement]
        public decimal total { get; set; }

    }
}
