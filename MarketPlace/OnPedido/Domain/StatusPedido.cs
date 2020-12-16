using System.Xml.Serialization;

namespace OnPedido.Domain
{
    public class StatusPedido
    {
        [XmlElement]
        public int status { get; set; }
        [XmlElement]
        public string texto { get; set; }
    }
}
