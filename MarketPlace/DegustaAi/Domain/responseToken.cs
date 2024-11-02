using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class responseToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_at { get; set; }
    }
}
