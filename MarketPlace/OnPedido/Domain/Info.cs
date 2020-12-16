using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Info
    {
        [XmlElement]
        public string ip { get; set; }

        [XmlElement(Type = typeof(Id))]
        public Id id { get; set; }

        [XmlElement]
        public string plataforma { get; set; }

        [XmlElement("status-pedido", Type = typeof(StatusPedido))]
        public StatusPedido status_pedido { get; set; }

        [XmlElement]
        public string impressao { get; set; }

        [XmlElement(Type = typeof(Data))]
        public Data data { get; set; }

        [XmlElement(Type = typeof(Agendamento))]
        public Agendamento agendamento { get; set; }
    }
}
