using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class cliente_cadastro
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string data_nascimento { get; set; }
        public string celular { get; set; }
        public string sexo { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
}
