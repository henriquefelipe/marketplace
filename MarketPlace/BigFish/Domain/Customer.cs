using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    [XmlRoot("response")]
    public class Customer
    {
        [XmlElement]
        public int cod_cliente { get; set; }
        [XmlElement]
        public byte importado { get; set; }
        [XmlElement]
        public string status { get; set; }
        [XmlElement]
        public string nome { get; set; }
        [XmlElement]
        public string sobrenome { get; set; }
        [XmlElement]
        public string responsavel { get; set; }
        [XmlElement]
        public string sexo { get; set; }
        [XmlElement]
        public string email { get; set; }
        [XmlElement]
        public string cnpj { get; set; }
        [XmlElement]
        public string cpf { get; set; }
        [XmlElement]
        public string inscricao_estadual { get; set; }
        [XmlElement]
        public string endereco { get; set; }
        [XmlElement]
        public string numero { get; set; }
        [XmlElement]
        public string complemento { get; set; }
        [XmlElement]
        public string bairro { get; set; }
        [XmlElement]
        public string cidade { get; set; }
        [XmlElement]
        public string estado { get; set; }
        [XmlElement]
        public string cep { get; set; }
        [XmlElement]
        public string telefone { get; set; }
        [XmlElement]
        public string celular { get; set; }
        [XmlElement("data_cadastro")]
        public string data_cadastro_raw { get; set; }
        [XmlElement("data_nascimento")]
        public string data_nascimento_raw { get; set; }

        [XmlIgnore]
        public DateTime data_cadastro
        {
            get => DateTime.Parse(data_cadastro_raw);
        }

        [XmlIgnore]
        public DateTime data_nascimento
        {
            get => DateTime.Parse(data_nascimento_raw);
        }
    }
}
