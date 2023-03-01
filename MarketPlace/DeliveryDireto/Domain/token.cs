using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class token
    {
        public string token_type { get; set; }
        public decimal expires_in { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
}
