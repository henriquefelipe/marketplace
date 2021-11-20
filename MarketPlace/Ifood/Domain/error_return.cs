using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class error_return
    {
        public error error { get; set; }
    }

    public class error
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}
