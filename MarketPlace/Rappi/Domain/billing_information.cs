using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Domain
{
    public class billing_information
    {
        public string billing_type { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string document_type { get; set; }
        public string document_number { get; set; }
    }
}
