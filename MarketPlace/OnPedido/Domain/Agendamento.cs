using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Agendamento
    {
        [XmlElement]
        public bool status { get; set; }
        [XmlElement(Type = typeof(Data))]
        public Data data { get; set; }
    }
}
