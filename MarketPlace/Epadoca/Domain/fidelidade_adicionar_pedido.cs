using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Domain
{
    public class fidelidade_adicionar_pedido
    {
        public fidelidade_adicionar_pedido()
        {
            produtoL = new List<fidelidade_adicionar_pedido_produto>();
        }

        public string codigo { get; set; }
        public string data { get; set; }
        public decimal valorTotal { get; set; }
        public decimal valorDesconto { get; set; }

        public fidelidade_adicionar_pedido_Cliente cliente { get; set; }
        public List<fidelidade_adicionar_pedido_produto> produtoL { get; set; }
    }

    public class fidelidade_adicionar_pedido_Cliente
    {
        public string codigoExterno { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string documento { get; set; }
    }

    public class fidelidade_adicionar_pedido_produto
    {
        public string sku { get; set; }
        public string nome { get; set; }
        public string categoria { get; set; }
        public decimal valorUnitario { get; set; }
        public decimal valorTotal { get; set; }
        public decimal quantidade { get; set; }
    }
}
