using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class response
    {
        public response()
        {
            pedidos = new List<pedido>();
        }

        public string status { get; set; }
        public string code { get; set; }
        public int pedidos_count { get; set; }
        public List<pedido> pedidos { get; set; }
        public int status_pedido {  get; set; }
        public string message { get; set; }
    }
}
