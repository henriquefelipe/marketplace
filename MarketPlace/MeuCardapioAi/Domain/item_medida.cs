using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class item_medida
    {
        public string nome { get; set; }
        public string sigla { get; set; }
        public decimal valorInicialPadrao { get; set; }
        public int incrementoPadrao { get; set; }
        public int id { get; set; }
    }
}
