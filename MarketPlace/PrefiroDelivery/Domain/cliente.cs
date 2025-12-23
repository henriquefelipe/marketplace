using System;
using System.Collections.Generic;
using System.Text;

namespace PrefiroDelivery.Domain
{
    public class cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string data_nascimento { get; set; }
    }

    public class endereco
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string referencia { get; set; }
        public string bairro { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
    }
}
