using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class clientes
    {
        public clientes()
        {
            data = new List<clientes_data>();
        }

        public int current_page { get; set; }
        public string first_page_url { get; set; }
        public int? from { get; set; }
        public string last_page { get; set; }
        public string last_page_url { get; set; }
        public string next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public string prev_page_url { get; set; }
        public int? to { get; set; }
        public int total { get; set; }

        public List<clientes_data> data { get; set; }
    }

    public class clientes_data
    {
        public int id_cliente { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string codigo_indicador { get; set; }
        public string origem_cadastro { get; set; }        
        public int pontos_conquistados_total { get; set; }
        public cartela_atual cartela_atual { get; set; }
    }

    public class cartela_atual
    {
        public int saldo { get; set; }
        public int saldo_carencia { get; set; }
    }
}
