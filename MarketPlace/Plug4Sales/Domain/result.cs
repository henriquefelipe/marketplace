using System;
using System.Collections.Generic;
using System.Text;

namespace Plug4Sales.Domain
{
    public class result
    {        
        public string error { get; set; }
        public string timeGenerated { get; set; }
        public bool success { get; set; }
    }

    public class result_orders : result
    {
        public string result { get; set; }        
    }

    public class result_token : result
    {
        public resultToken_token result { get; set; }
    }

    public class resultToken_token
    {
        public string token { get; set; }
        public string type { get; set; }
        public int expiresIn { get; set; }
    }
}
