using System;
using System.Collections.Generic;
using System.Text;

namespace Iorion19.Domain
{
    public class endereco_de_entrega
    {
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string referencia { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
    }
}
