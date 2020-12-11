using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class endereco
    {
        public int id { get; set; }
        public endereco_cidade cidade { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string numero { get; set; }
        public string descricao { get; set; }
        public string localizacao { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public endereco_estado estado { get; set; }
    }

    public class endereco_cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
    }

    public class endereco_estado
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
    }
}
