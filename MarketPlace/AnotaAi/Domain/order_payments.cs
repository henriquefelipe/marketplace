using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Domain
{
    public class order_payments
    {
        public string name { get; set; }
        public string code { get; set; }
        public string cardSelected { get; set; }
        public string changeFor { get; set; }
        public bool prepaid { get; set; }
    }
}
