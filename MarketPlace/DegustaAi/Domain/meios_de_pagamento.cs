using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class meios_de_pagamento
    {
        public meios_de_pagamento()
        {
            meios = new List<meios_de_pagamento_meios>();
        }

        public List<meios_de_pagamento_meios> meios { get; set; }
    }

    public class meios_de_pagamento_meios
    {
        public string forma_id { get; set; }
        public string name { get; set; }
        public decimal troco { get; set; }
        public decimal valor { get; set; }
        public string categoria { get; set; }
        public int? online { get; set; }
    }
}
