using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class erroResult
    {
        public erroResult()
        {
            messages = new List<string>();
        }

        public bool error { get; set; }
        public List<string> messages { get; set; }
    }
}
