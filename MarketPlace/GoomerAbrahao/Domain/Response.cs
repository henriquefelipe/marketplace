using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoomerAbrahao.Domain
{
    public class Response<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
