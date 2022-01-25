using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace
{
    public static class Util
    {
        public static string InnerException(Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            return ex.Message;
        }


        public static List<string> Write( RestObject rootObject)
        {
            var list = new List<string>();
            list.Add("clientId: " + rootObject.args.clientId);
            list.Add("Accept: " + rootObject.headers.Accept);
            list.Add("AcceptEncoding: " + rootObject.headers.AcceptEncoding);
            list.Add("AcceptLanguage: " + rootObject.headers.AcceptLanguage);
            list.Add("Authorization: " + rootObject.headers.Authorization);
            list.Add("Connection: " + rootObject.headers.Connection);
            list.Add("Dnt: " + rootObject.headers.Dnt);
            list.Add("Host: " + rootObject.headers.Host);
            list.Add("Origin: " + rootObject.headers.Origin);
            list.Add("Referer: " + rootObject.headers.Referer);
            list.Add("UserAgent: " + rootObject.headers.UserAgent);
            list.Add("origin: " + rootObject.origin);
            list.Add("url: " + rootObject.url);
            list.Add("data: " + rootObject.data);
            list.Add("files: ");
            foreach (KeyValuePair<string, string> kvp in rootObject.files ?? Enumerable.Empty<KeyValuePair<string, string>>())
            {
                list.Add("\t" + kvp.Key + ": " + kvp.Value);
            }
            return list;
        }

    }    
}
