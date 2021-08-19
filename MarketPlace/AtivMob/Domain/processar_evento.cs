using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class processar_evento
    {
        public processar_evento()
        {
            events_ids = new List<string>();
        }

        public List<string> events_ids { get; set; }
    }
}
