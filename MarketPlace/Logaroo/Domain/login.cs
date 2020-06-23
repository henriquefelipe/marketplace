using System.Collections.Generic;

namespace Logaroo.Domain
{
    public class login
    {
        public loginData data { get; set; }
    }

    public class loginData
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public List<loginAddresses> addresses { get; set; }
        public List<loginRoles> roles { get; set; }
        public string token { get; set; }
        public int status { get; set; }
    }

    public class loginAddresses
    {

    }

    public class loginRoles
    {

    }

    public class loginStores
    {

    }
}
