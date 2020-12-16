using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Status
    {
        [XmlElement]
        public bool status { get; set; }

        [XmlElement("novos-pedidos")]
        public long novos_pedidos { get; set; }

        [XmlElement("clientes-online")]
        public long clientes_online { get; set; }

        [XmlElement("codigo-erro")]
        public string codigo_erro { get; set; }

        [XmlElement("versao-cache")]
        public long versao_cache { get; set; }

        [XmlElement]
        public string mensagem { get; set; }

        [XmlElement(Type = typeof(Status_Pedidos))]
        public Status_Pedidos pedidos { get; set; }
    }
}
