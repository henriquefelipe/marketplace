using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Domain
{
    public class responseValidacao
    {
        public responseValidacao2 response { get; set; }
    }

    public class responseValidacao2
    {
        public int code { get; set; }
        public List<error> errors { get; set; }
    }
}
