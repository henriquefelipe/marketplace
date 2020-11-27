using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class order_result
    {
        public bool sucesso { get; set; }
        public order data { get; set; }
    }

    public class orders_result
    {
        public bool sucesso { get; set; }
        public orders_result_pedido data { get; set; }        
    }

    public class orders_result_pedido
    {
        public List<order> pedidos { get; set; }
        public string codigoUltimo { get; set; }
    }
}
