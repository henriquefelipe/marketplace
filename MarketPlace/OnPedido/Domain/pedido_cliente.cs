using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_cliente
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string qtd_pedidos { get; set; }
        public pedido_cliente_celular celular { get; set; }
        public pedido_cliente_telefone telefone { get; set; }
        public pedido_cliente_endereco endereco { get; set; }
    }
}
