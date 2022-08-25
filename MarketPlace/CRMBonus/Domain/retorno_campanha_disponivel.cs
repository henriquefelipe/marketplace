using System;
using System.Collections.Generic;
using System.Text;

namespace CRMBonus.Domain
{
    public class retorno_campanha_disponivel
    {
        public retorno_campanha_disponivel()
        {
            campanhas = new List<retorno_campanha_disponivel_campanha>();
        }

        public int loja_id { get; set; }
        public string msg { get; set; }
        public List<retorno_campanha_disponivel_campanha> campanhas { get; set; }
    }

    public class retorno_campanha_disponivel_campanha
    {
        public int id { get; set; }
        public string name { get; set; }
        public string texto { get; set; }
        public decimal valor { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
    }
}
