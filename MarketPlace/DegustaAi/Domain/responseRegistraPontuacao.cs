using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class responseRegistraPontuacao : response_base
    {
        public responseRegistraPontuacaoData data { get; set; }
    }

    public class responseRegistraPontuacaoData
    {
        public string pontos { get; set; }
        public int visitas { get; set; }
        public int resgates { get; set; }

        public Dictionary<string, premios> premios { get; set; }
        public responseRegistraPontuacaoDataDadosCadastro dados_cadastro { get; set; }
    }


    public class responseRegistraPontuacaoDataDadosCadastro
    {
        public string cpf { get; set; }
        public string nome_completo { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string genero { get; set; }
        public string data_nascimento { get; set; }
    }
}
