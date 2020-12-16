using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Endereco
    {
        [XmlElement]
        public string cep { get; set; }
        [XmlElement]
        public string rua { get; set; }

        [XmlElement]
        public long? numero { get; set; }

        [XmlElement]
        public string bairro { get; set; }
        [XmlElement]
        public string cidade { get; set; }
        [XmlElement]
        public string complemento { get; set; }
        [XmlElement]
        public string referencia { get; set; }
        [XmlElement]
        public string formatado { get; set; }
        [XmlElement]
        public string uf { get; set; }
    }
}
