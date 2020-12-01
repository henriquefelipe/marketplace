using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Domain
{
    public class result
    {
        public bool success { get; set; }
        public string message { get; set; }
        public result_info info { get; set; }
    }

    public class result_info
    {
        public int check { get; set; }
    }
}
