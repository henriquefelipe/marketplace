using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class produto
    {
        public string id { get; set; }
        public string nome { get; set; }
        public decimal qtd { get; set; }
        public bool promocao { get; set; }
        public produto_comentario comentario { get; set; }
        public produto_desconto desconto { get; set; }
        public produto_valor valor { get; set; }
    }
}
