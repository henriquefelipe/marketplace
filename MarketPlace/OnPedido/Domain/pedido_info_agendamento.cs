using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_info_agendamento
    {
        public bool status { get; set; }
        public pedido_info_agendamento_data data { get; set; }
    }
}
