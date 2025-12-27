using System;
using System.Collections.Generic;
using System.Text;

namespace Repediu.Domain
{
    public class resultError
    {
        public error error { get; set; }
    }

    public class error
    {
        public string message { get; set; }
    }
}
