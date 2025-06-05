using System;
using System.Collections.Generic;
using System.Text;

namespace Repediu.Domain
{
    public class payments
    {
        public payments()
        {
            methods = new List<payments_methods>();
        }

        public int prepaid { get; set; }
        public int pending { get; set; }
        public List<payments_methods> methods { get; set; }
    }

    public class payments_methods
    {
        public decimal value { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string method { get; set; }
        public string brand { get; set; }
        public string methodInfo { get; set; }
        public decimal changeFor { get; set; }
    }
}
