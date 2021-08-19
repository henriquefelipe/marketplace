using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class evento
    {
        public string event_id { get; set; }
        public string event_code { get; set; }
        public string event_title { get; set; }
        public string event_dth { get; set; }
        public string codigo_atividade { get; set; }
        public string codigo_roteiro { get; set; }
        public string codigo_agente { get; set; }
        public string nome_agente { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
