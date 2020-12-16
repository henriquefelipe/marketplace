using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Cliente
    {
        [XmlElement]
        public string nome { get; set; }

        [XmlElement("qtd-pedidos")]
        public long qtd_pedidos { get; set; }

        [XmlElement(Type = typeof(Celular))]
        public Celular celular { get; set; }

        [XmlElement(Type = typeof(Endereco))]
        public Endereco endereco { get; set; }
    }
}
