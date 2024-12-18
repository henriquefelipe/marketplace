using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    public class Order
    {
        [XmlElement]
        public int cod_pedido {  get; set; }
        [XmlElement]
        public int cod_cliente { get; set; }
        [XmlElement]
        public string cpf {  get; set; }
        [XmlElement]
        public string cnpj { get; set; }
        [XmlElement]
        public string status { get; set; }
        [XmlElement("status_data")]
        public string status_data_raw { get; set; }
        [XmlElement]
        public string status_descricao { get; set; }
        [XmlElement]
        public string boleto_url { get; set; }
        [XmlElement("data_programada")]
        public string data_programada_raw { get; set; }
        [XmlElement]
        public string hora_programada { get; set; }
        [XmlElement("data_pedido")]
        public string data_pedido_raw { get; set; }
        [XmlElement]
        public string ent_responsavel { get; set; }
        [XmlElement]
        public string ent_endereco { get; set; }
        [XmlElement]
        public string ent_numero { get; set; }
        [XmlElement]
        public string ent_complemento { get; set; }
        [XmlElement]
        public string ent_bairro { get; set; }
        [XmlElement]
        public string ent_cidade { get; set; }
        [XmlElement]
        public string ent_estado { get; set; }
        [XmlElement]
        public string ent_cep { get; set; }
        [XmlElement]
        public string forma_entrega { get; set; }
        [XmlElement]
        public int codigo_pagamento { get; set; }
        [XmlElement]
        public string forma_pagamento { get; set; }
        [XmlElement]
        public string observacoes { get; set; }
        [XmlElement]
        public string certificado { get; set; }
        [XmlElement]
        public decimal valor_total { get; set; }
        [XmlElement]
        public decimal valor_frete { get; set; }
        [XmlElement]
        public decimal valor_certificado { get; set; }
        [XmlElement]
        public decimal valor_desconto { get; set; }
        [XmlElement]
        public decimal valor_desconto_credito { get; set; }
        [XmlElement]
        public decimal valor_troco { get; set; }
        [XmlElement]
        public int parcelas { get; set; }
        [XmlElement]
        public decimal valor_parcela { get; set; }
        [XmlArray("itens")]
        [XmlArrayItem("rowitens")]
        public Items[] itens { get; set; }

        [XmlIgnore]
        public DateTime status_data
        {
            get => DateTime.Parse(status_data_raw);
        }

        [XmlIgnore]
        public DateTime data_pedido
        {
            get => DateTime.Parse(data_pedido_raw);
        }

        [XmlIgnore]
        public DateTime data_programada
        {
            get => DateTime.Parse(data_programada_raw);
        }
    }
}
