using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Status_Pedidos
    {
        [XmlIgnore]
        public string ID => "STATUS_PEDIDOS_ONPEDIDO";

        [XmlElement("nao-recebido", Type = typeof(PedidosIDs))]
        public PedidosIDs NaoRecebidos { get; set; }

        [XmlElement("recebido", Type = typeof(PedidosIDs))]
        public PedidosIDs Recebidos { get; set; }

        [XmlElement("confirmado", Type = typeof(PedidosIDs))]
        public PedidosIDs Confirmados { get; set; }

        [XmlElement("despachado", Type = typeof(PedidosIDs))]
        public PedidosIDs Despachados { get; set; }

        [XmlElement("entregue", Type = typeof(PedidosIDs))]
        public PedidosIDs Entregues { get; set; }

        [XmlElement("cancelado", Type = typeof(PedidosIDs))]
        public PedidosIDs Cancelados { get; set; }

        [XmlElement("avaliado", Type = typeof(PedidosIDs))]
        public PedidosIDs Avaliados { get; set; }
        
    }
}
