using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Domain
{
    public class responseError
    {
        public response response { get; set; }
    }

    public class response
    {
        public int code { get; set; }
        public string error { get; set; }
    }
}

