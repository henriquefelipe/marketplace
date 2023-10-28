using System;
using System.Collections.Generic;
using System.Text;

namespace EuFalo.Domain
{
    public class resgate
    {
        public resgate()
        {
            mensagem = new List<string>();
            success = new List<resgate_sucess_error>();
            errors = new List<resgate_sucess_error>();
        }

        public List<string> mensagem { get; set; }
        public List<resgate_sucess_error> success { get; set; }
        public List<resgate_sucess_error> errors { get; set; }
    }

    public class resgate_sucess_error
    {
        public resgate_item item { get; set; }
    }

    public class resgate_item
    {
        public string cpf { get; set; }
        public string dataResgate { get; set; }
        public string valor { get; set; }

        
    }
}
