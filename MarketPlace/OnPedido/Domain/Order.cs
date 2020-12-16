using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    [XmlType("pedido")]
    public class Order
    {
        [XmlElement(Type = typeof(Info))]
        public Info info { get; set; }

        [XmlElement(Type = typeof(Cliente))]
        public Cliente cliente { get; set; }

        [XmlArrayItem("produto")]
        public Produto[] produtos { get; set; }

        [XmlElement(Type = typeof(TotalizacaoPedido))]
        public TotalizacaoPedido valor { get; set; }

        //public override string ToString()
        //{
        //    var memoryStream = new MemoryStream();
        //    var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);

        //    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Order));
        //    serializer.Serialize(streamWriter, this);

        //    return Encoding.UTF8.GetString(memoryStream.ToArray());
        //}
    }
}
