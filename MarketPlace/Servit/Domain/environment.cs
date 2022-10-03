using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class environment
    {
        public int id { get; set; }
        public string name { get; set; }
        public environment_printers printers { get; set; }

    }

    public class environment_printers
    { 
        [JsonProperty("default")]
        public environment_printers_printer defaulte { get; set; }

        public environment_printers_printer conference { get; set; }
        public environment_printers_printer exclusion { get; set; }
    }

    public class environment_printers_printer
    {
        public int id { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public string ip_address { get; set; }
        public string port { get; set; }
    }
}
