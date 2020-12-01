using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Domain
{
    public class result_order
    {
        public bool success { get; set; }
        public string message { get; set; }
        public order info { get; set; }
    }
}
