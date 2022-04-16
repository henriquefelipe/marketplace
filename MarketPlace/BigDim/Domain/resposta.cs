using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class resposta
    {       
        public resposta()
        {
            pedidoProdutoListVO = new List<pedidoProdutoList>();
        }

        public pedido pedido { get; set; }
        public string pedidoTxt { get; set; }
        public string whatsAppEmpresa { get; set; }
        public bool imprimirCategoriaAdicional { get; set; }
        public List<pedidoProdutoList> pedidoProdutoListVO { get; set; }
       
    }
}
