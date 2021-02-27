using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class wspdvresponse<TResult>
    {
        [JsonProperty(PropertyName = "wspdv-response")]
        public wspdv_response<TResult> wspdvResponse { get; set; }
    }

    public class wspdv_response<TResult>
    {
        [JsonProperty(PropertyName = "response-status")]
        public string responseStatus { get; set; }

        [JsonProperty(PropertyName = "response-message")]
        public string responseMessage { get; set; }

        [JsonProperty(PropertyName = "response-date")]
        public string responseDate { get; set; }

        [JsonProperty(PropertyName = "response-numFound")]
        public string response_numFound { get; set; }

        [JsonProperty(PropertyName = "response-body")]
        public TResult responseBody { get; set; }
    }

    
}
