using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class open_close_result
    {
        public open_close_result_data data { get; set; }
    }

    public class open_close_result_data
    {
        public string store_id { get; set; }
        public string status { get; set; }
    }
}
