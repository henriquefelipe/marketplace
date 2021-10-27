using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class token2
    {
        public string accessToken { get; set; }
        public string type { get; set; }
        public int expiresIn { get; set; }
    }
}
