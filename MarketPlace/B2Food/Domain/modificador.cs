using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Food.Domain
{
    public class modificador
    {
        public int id { get; set; }
        public object catalogoModificadorID { get; set; }
        public int catalogoTamanhoID { get; set; }
        public int pedidoItemID { get; set; }
        public string nome { get; set; }
        public string nomeGrupo { get; set; }
        public int tipo { get; set; }
        public decimal quantidade { get; set; }
        public decimal preco { get; set; }
        public string criadoEm { get; set; }
        public string atualizadoEm { get; set; }
    }
}
