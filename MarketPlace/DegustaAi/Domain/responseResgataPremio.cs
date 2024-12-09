using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class responseResgataPremio : response_base
    {
        public responseResgataPremioData data { get; set; }
    }

    public class responseResgataPremioData
    {
        public responseResgataPremioDataPremio premio { get; set; }
        public responseResgataPremioDataResumoUsuario resumo_usuario { get; set; }
    }

    public class responseResgataPremioDataPremio
    {
        public string nome { get; set; }
        public int pontos { get; set; }
    }

    public class responseResgataPremioDataResumoUsuario
    {
        public string pontos { get; set; }
        public int visitas { get; set; }
        public int resgates { get; set; }
        public responseResgataPremioDataResumoUsuarioDadosCadastro dados_cadastro { get; set; }
    }

    public class responseResgataPremioDataResumoUsuarioDadosCadastro
    {
        public string cpf { get; set; }
        public string nome_completo { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string genero { get; set; }
        public string data_nascimento { get; set; }
    }
}
