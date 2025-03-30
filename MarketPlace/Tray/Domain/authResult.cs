using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class authResult
    {
        public string code {  get; set; }
        public string message { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string date_expiration_access_token { get; set; }
        public string date_expiration_refresh_token { get; set; }
        public string date_activated { get; set; }
        public string api_host { get; set; }
        public string store_id { get; set; }
    }
}
