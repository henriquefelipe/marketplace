using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class atendente
    {
        public int id_atendente {  get; set; }
        public int id_parceiro { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public int ativo { get; set; }
    }
}
