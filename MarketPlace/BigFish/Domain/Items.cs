using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    public class Items
    {
        [XmlElement]
        public int cod_item { get; set; }
        [XmlElement]
        public string cod_produto_externo { get; set; }
        [XmlElement]
        public int cod_valor { get; set; }
        [XmlElement]
        public string codigo { get; set; }
        [XmlElement]
        public string descricao { get; set; }
        [XmlElement]
        public int quantidade { get; set; }
        [XmlElement]
        public decimal valor { get; set; }
        [XmlElement]
        public decimal valor_real { get; set; }
        [XmlArray("produtos")]
        [XmlArrayItem("rowprodutos")]
        public Produtos[] produtos { get; set; }
        [XmlArray("cardapio")]
        [XmlArrayItem("rowprodutos")]
        public Cardapio[] cardapio { get; set; }
    }
}
