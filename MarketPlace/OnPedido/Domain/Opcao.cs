using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    [XmlType("opcao")]
    public class Opcao : IItem
    {
        [XmlElement]
        public string id;
        [XmlElement]
        public string nome { get; set; }
        [XmlElement]
        public decimal qtd { get; set; }
        [XmlElement(Type = typeof(Valor))]
        public Valor valor { get; set; }

        [XmlIgnore]
        public string DescricaoItem => this.nome;

        [XmlIgnore]
        public string QuantidadeItem => "";

        [XmlIgnore]
        public string ValorItem { get => this.valor.total.ToString("C") + "   "; }
    }
}
