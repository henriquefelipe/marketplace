using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Comentario : IItem
    {
        [XmlElement]
        public bool status { get; set; }
        [XmlElement]
        public string comentario { get; set; }

        [XmlIgnore]
        public string DescricaoItem => $"Observações: {this.comentario}";

        [XmlIgnore]
        public string QuantidadeItem => "➤";

        [XmlIgnore]
        public string ValorItem { get => ""; }
    }
}
