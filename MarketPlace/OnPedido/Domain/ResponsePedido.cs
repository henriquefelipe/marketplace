using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{   
    [XmlRoot("onpedido")]
    [Serializable]
    public class ResponseOrders
    {
        [XmlElement(Type = typeof(Status))]
        public Status status { get; set; }

        [XmlArrayItem("pedido", Type = typeof(Order))]
        public Order[] pedido { get; set; }
    }
}