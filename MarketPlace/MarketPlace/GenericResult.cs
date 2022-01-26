using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace
{
    public class GenericSimpleResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Json { get; set; }

    }

    public class GenericResult<TResult> : GenericSimpleResult
    {
        public TResult Result { get; set; }

        public string Request { get; set; }
        public string Response { get; set; }

    }


    public class Args
    {
        public string clientId { get; set; }
    }

    public class Headers
    {
        public string Accept { get; set; }

        public string AcceptEncoding { get; set; }

        public string AcceptLanguage { get; set; }

        public string Authorization { get; set; }

        public string Connection { get; set; }

        public string Dnt { get; set; }

        public string Host { get; set; }

        public string Origin { get; set; }

        public string Referer { get; set; }

        public string UserAgent { get; set; }
    }

    public class RestObject
    {
        public Args args { get; set; }

        public Headers headers { get; set; }

        public string origin { get; set; }

        public string url { get; set; }

        public string data { get; set; }

        public Dictionary<string, string> files { get; set; }
    }


}
