using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class pedidoProduto
    {
        public int id { get; set; }        
        public produto produto { get; set; }
        public string descricaoProduto { get; set; }
        public string nomeProduto { get; set; }
        public decimal valorUnitario { get; set; }
        public string quantidade { get; set; }
        public decimal valorTotal { get; set; }
        public string observacao { get; set; }
        public int ordem { get; set; }
    }
}
