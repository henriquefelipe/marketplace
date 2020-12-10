using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_info
    {
        public string ip { get; set; }
        public pedido_info_id id { get; set; }
        public string plataforma { get; set; }
        public string observacao { get; set; }
        public pedido_info_status_pedido status_pedido { get; set; }
        public bool impressao { get; set; }
        public pedido_info_data data { get; set; }
        public pedido_info_previsao previsao { get; set; }
        public pedido_info_agendamento agendamento { get; set; }
        public pedido_info_encomenda encomenda { get; set; }
    }
}
