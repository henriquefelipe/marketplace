using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Domain
{
    public class responseCheckBalance
    {
        public responseCheckBalance2 response { get; set; }
    }

    public class responseCheckBalance2
    {
        public responseCheckBalance2()
        {
            errors = new List<error>();
        }

        public int code { get; set; }
        public bool has_balance { get; set; }
        public List<error> errors { get; set; }
    }
}
