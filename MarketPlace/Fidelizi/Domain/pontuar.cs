using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Fidelizi.Domain
{
    public class pontuar
    {
        public int id_cartela_cliente {  get; set; }
        public int id_parceiro_origem { get; set; }
        public int qtd_ponto { get; set; }
        public string date_ponto { get; set; }
        public string client_check_id { get; set; }
        public int id_ponto { get; set; }
        public int id_cliente { get; set; }
        public pontuar_ponto_dinheiro ponto_dinheiro { get; set; }
    }

    public class pontuar_ponto_dinheiro
    {
        public int id_ponto_dinheiro { get; set; }
        public int id_ponto { get; set; }
        public string dinheiro_gasto { get; set; }
        public int conversao_ponto { get; set; }
        public string conversao_dinheiro { get; set; }
    }    
}
