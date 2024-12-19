using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    public class Cardapio
    {
        [XmlElement]
        public int cod_valor { get; set; }
        [XmlElement]
        public string descricao { get; set; }
        [XmlElement]
        public string codigo { get; set; }
        [XmlElement]
        public decimal valor { get; set; }
        [XmlElement]
        public string periodo { get; set; }
        [XmlElement]
        public string dia { get; set; }
        [XmlElement]
        public string unidade { get; set; }
        [XmlElement]
        public string unidade_valor { get; set; }
    }
}
