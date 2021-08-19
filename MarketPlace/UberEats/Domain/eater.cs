using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class eater
    {
        public string first_name { get; set; }
        public string phone { get; set; }
        public string phone_code { get; set; }
        public string last_name { get; set; }
        public delivery delivery { get; set; }
    }
}
