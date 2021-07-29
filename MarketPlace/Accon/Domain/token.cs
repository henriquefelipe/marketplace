using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class tokenAuth
    {
        public tokenAuthUser user { get; set; }
        public string token { get; set; }
    }

    public class tokenAuthUser
    {
        public tokenAuthUser()
        {
            stores = new List<tokenAuthStore>();
            roles = new List<string>();
        }

        public bool is_staff { get; set; }
        public bool is_active { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string document { get; set; }
        public string network { get; set; }
        public List<tokenAuthStore> stores { get; set; }
        public List<string> roles { get; set; }
    }

    public class tokenAuthStore
    {
        public string _id { get; set; }
        public string name { get; set; }
    }
}
