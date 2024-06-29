using System;
using System.Collections.Generic;
using System.Text;

namespace EuFalo.Domain
{
    public class lista_cpf
    {
        public string chave { get; set; }
        public string contatoCI { get; set; }
        public string numeroVoucher { get; set; }
        public string cpf { get; set; }
        public DateTime data { get; set; }
        public int prazoEntrega { get; set; }
        public string premio { get; set; }
        public decimal valor { get; set; }
    }
}
