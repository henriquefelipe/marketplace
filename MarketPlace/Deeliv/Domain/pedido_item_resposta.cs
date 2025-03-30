using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeliv.Domain
{
    public class pedido_item_resposta
    {
        public int res_id { get; set; }
        public string res_sku { get; set; }
        public string res_titulo { get; set; }
        public decimal res_preco { get; set; }
        public decimal res_quantidade { get; set; }
        public decimal? res_fatordivisao { get; set; }
        public int car_res_id { get; set; }
    }
}
