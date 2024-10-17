using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class usuario
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public int telefone_codigo_pais { get; set; }
        public string data_nascimento { get; set; }
        public string genero { get; set; }
    }
}
