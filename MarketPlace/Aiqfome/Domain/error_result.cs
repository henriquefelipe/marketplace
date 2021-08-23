using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class error_result
    {
        public bool success { get; set; }
        public error_result_data data { get; set; }
    }

    public class error_result_data
    {
        public string message { get; set; }
        public string track_id { get; set; }
        public string error_code { get; set; }
    }
}

