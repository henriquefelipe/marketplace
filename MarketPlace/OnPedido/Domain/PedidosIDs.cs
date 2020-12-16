using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class PedidosIDs
    {
        [XmlElement("id")]
        public List<long> IDs { get; set; }
    }
}
