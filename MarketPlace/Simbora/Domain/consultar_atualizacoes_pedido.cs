using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Domain
{
    public class consultar_atualizacoes_pedido
    {
        public consultar_atualizacoes_pedido()
        {
            orders = new List<consultar_atualizacoes_pedido_orders>();
        }

        public string status { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public List<consultar_atualizacoes_pedido_orders> orders { get; set; }
    }


    public class consultar_atualizacoes_pedido_orders
    {        
        public string orderId { get; set; }
        public string status { get; set; }
        public string driverName { get; set; }
        public string driverCode { get; set; }
        public string driverPhone { get; set; }
    }
}
