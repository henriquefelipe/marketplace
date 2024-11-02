using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class response : response_base
    {
        public response()
        {
            pedidos = new List<pedido>();
        }
       
        public int pedidos_count { get; set; }
        public List<pedido> pedidos { get; set; }
        public int status_pedido {  get; set; }
       
    }
}
