using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class pedidoProdutoList
    {
        public pedidoProdutoList()
        {
            pedidoProdutoAdicionalList = new List<pedidoProdutoAdicional>();
        }

        public pedidoProduto pedidoProduto { get; set; }
        public List<pedidoProdutoAdicional> pedidoProdutoAdicionalList { get; set; }
    }
}
