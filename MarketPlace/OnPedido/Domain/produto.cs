using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    [XmlType("produto")]
    public class Produto : IItem
    {
        [XmlElement]
        public string id { get; set; }

        [XmlElement]
        public string nome { get; set; }

        [XmlElement]
        public decimal qtd { get; set; }

        //[XmlArrayItem("opcao")]
        [XmlElement("opcao")]
        public Opcao[] opcoes { get; set; }

        [XmlElement(Type = typeof(Comentario))]
        public Comentario comentario { get; set; }

        [XmlElement(Type = typeof(Desconto))]
        public Desconto desconto { get; set; }

        [XmlElement(Type = typeof(TotalizacaoProduto))]
        public TotalizacaoProduto valor { get; set; }

        [XmlIgnore]
        public decimal valor_total_produto
        {
            get
            {
                return this.valor.total;
            }
        }

        [XmlIgnore]
        public string DescricaoItem => this.nome;

        [XmlIgnore]
        public string QuantidadeItem => this.qtd.ToString();

        [XmlIgnore]
        public string ValorItem { get => this.valor.total.ToString("C"); }
    }
}
