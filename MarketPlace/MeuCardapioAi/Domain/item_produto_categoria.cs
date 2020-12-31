using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class item_produto_categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        //"impressoras": [],
        public int posicao { get; set; }
        public bool disponivel { get; set; }
    }
}
