using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class wspdvresponse
    {
        //{"wspdv-response":{"response-status":"00","response-message":"0 pedidos encontrados","response-date":"26\/02\/2021 04:06:31","response-numFound":"0","response-body":{"@class":"list","codPedido":[] } }

        [JsonProperty("wspdv-response")]
        public wspdv_response wspdv_response { get; set; }
    }

    public class wspdv_response
    {
        [JsonProperty("response-status")]
        public string response_status { get; set; }

        [JsonProperty("response-message")]
        public string response_message { get; set; }

        [JsonProperty("response-date")]
        public string response_date { get; set; }

        [JsonProperty("response-numFound")]
        public string response_numFound { get; set; }

        [JsonProperty("response-body")]
        public response_body response_body { get; set; }
    }

    public class response_body
    {
        [JsonProperty("@class")]
        public string _class { get; set; }

        public List<string> codPedido { get; set; }
    }
}
