using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class pedidoProdutoAdicional
    {
        public int id { get; set; }
        public int pedidoProdutoId { get; set; }
        public int produtoAdicionalID { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public decimal quantidade { get; set; }
        public int ordem { get; set; }
        public string codigoPdv { get; set; }
    }
}
