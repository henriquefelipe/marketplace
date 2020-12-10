using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_info_previsao
    {
        public bool status { get; set; }
        public pedido_info_previsao_data data { get; set; }
    }
}
