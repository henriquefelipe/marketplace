using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class userCodeResult
    {
        public string userCode { get; set; }
        public string authorizationCodeVerifier { get; set; }
        public string verificationUrl { get; set; }
        public string verificationUrlComplete { get; set; }
        public int expiresIn { get; set; }
    }
}
