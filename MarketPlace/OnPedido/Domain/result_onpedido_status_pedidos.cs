using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class result_onpedido_status_pedidos
    {
        public result_onpedido_status_pedidos_lista nao_recebido { get; set; }
        public result_onpedido_status_pedidos_lista recebido { get; set; }
        public result_onpedido_status_pedidos_lista confirmado { get; set; }
        public result_onpedido_status_pedidos_lista despachado { get; set; }
        public result_onpedido_status_pedidos_lista entregue { get; set; }
        public result_onpedido_status_pedidos_lista cancelado { get; set; }
        public result_onpedido_status_pedidos_lista avaliado { get; set; }
    }
}
