using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Domain
{
    public class consultar_pedido_roteirizado
    {
        public consultar_pedido_roteirizado()
        {
            routers = new List<consultar_pedido_roteirizado_routers>();
        }

        public string status { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public List<consultar_pedido_roteirizado_routers> routers { get; set; }
    }


    public class consultar_pedido_roteirizado_routers
    {        
        public List<string> orders { get; set; }
    }
}
