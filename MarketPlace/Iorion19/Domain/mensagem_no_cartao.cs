using System;
using System.Collections.Generic;
using System.Text;

namespace Iorion19.Domain
{
    public class mensagem_no_cartao
    {
        public mensagem_no_cartao_campos campos {  get; set; }
    }

    public class mensagem_no_cartao_campos
    {
        public string de_text { get; set; }
        public string anonimo { get; set; }
        public string para_text { get; set; }
        public string mensagem_text { get; set; }
        public string nome_destinatario { get; set; }
        public string telefone_destinatario { get; set; }
    }
}
