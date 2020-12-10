using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_info_encomenda
    {
        public bool status { get; set; }
        public pedido_info_encomenda_data data { get; set; }
    }
}
