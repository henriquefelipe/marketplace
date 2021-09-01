using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order_read_result
    {
        public order_read_result_detalhe data { get; set; }
    }

    public class order_read_result_detalhe
    {
        public string read_at { get; set; }
        public string read_by { get; set; }
        public string ready_at { get; set; }
    }
}
