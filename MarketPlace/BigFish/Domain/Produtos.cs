using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    public class Produtos
    {
        [XmlElement]
        public int cod_valor {  get; set; }
        [XmlElement]
        public string descricao { get; set; }
        [XmlElement]
        public int quantidade { get; set; }
        [XmlElement]
        public string codigo { get; set; }
        [XmlElement]
        public decimal valor { get; set; }
    }
}
