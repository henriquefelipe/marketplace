using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class error_cancel
    {
        public error_cancel_error error {  get; set; }        
    }

    public class error_cancel_error
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}

