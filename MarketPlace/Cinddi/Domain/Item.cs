using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinddi.Domain
{
    public class Item
    {
        public string CATEGORIA { get; set; }
        public string CODIGOPDV { get; set; }
        public string DESCRICAOPRODUTO { get; set; }
        public decimal QUANTIDADE { get; set; }
        public decimal PRECOVENDA { get; set; }
        public decimal PRECOTOTAL { get; set; }
        public decimal PONTOS { get; set; }
        public string OBSERVACAO { get; set; }

        public List<Acompanhamento> Acompanhamentos { get; set; }
    }
}
