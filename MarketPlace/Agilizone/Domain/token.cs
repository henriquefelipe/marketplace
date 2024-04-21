using System;
using System.Collections.Generic;
using System.Text;

namespace Agilizone.Domain
{
    public class token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    public class token_secret
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}
