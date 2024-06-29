using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class erro
    {
        public bool error { get; set; }
        public erro_messages messages { get; set; }
    }

    public class erro_messages
    {
        public erro_messages()
        {
            cpf = new List<string>();
            id_cliente = new List<string>();
            nome = new List<string>();
            celular = new List<string>();
            email = new List<string>();
            data_nascimento = new List<string>();
            sexo = new List<string>();
            estado = new List<string>();
        }

        public List<string> cpf { get; set; }
        public List<string> id_cliente { get; set; }
        public List<string> nome { get; set; }
        public List<string> celular { get; set; }
        public List<string> email { get; set; }        
        public List<string> data_nascimento { get; set; }
        public List<string> sexo { get; set; }
        public List<string> estado { get; set; }
    }
}
