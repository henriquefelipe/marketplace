using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class item
    {
        public int quantidade { get; set; }
        public string obs { get; set; }
        public decimal valor { get; set; }
        public string valor_pontos { get; set; }
        public int resgatado { get; set; }
        public string cod_pdv { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public List<item> complementos {  get; set; }
    }
}
