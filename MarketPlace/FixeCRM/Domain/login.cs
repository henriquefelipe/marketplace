using System;
using System.Collections.Generic;
using System.Text;

namespace FixeCRM.Domain
{
    public class login
    {
        public string token { get; set; }
        public token_user user { get; set; }

    }

    public class token_user
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        //public string stores [] { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string models { get; set; }
        public string location { get; set; }
        public string pinNumber { get; set; }
        public string uniqueId { get; set; }
        public string id_passbooks { get; set; }
        //"fields": [],
        public long expirationDate { get; set; }
        public bool completedRegister { get; set; }
        //"deviceLibraryIdentifier": []
    }
}
