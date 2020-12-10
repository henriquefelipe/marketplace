using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class result_onpedido_status
    {
        public bool status { get; set; }
        public int novos_pedidos { get; set; }
        public string versao_cache { get; set; }
        public int clientes_online { get; set; }
        public string mensagem { get; set; }
        public result_onpedido_status_pedidos pedidos { get; set; }
    }
}
