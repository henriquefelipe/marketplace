using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iorion19.Domain
{
    public class pedido
    {
        public pedido()
        {
            itens = new List<item>();
        }

        [JsonProperty("ref")]
        public int referencia { get; set; }
        public string obs { get; set; }
        public string aceito_em { get; set; }
        public string producao_em { get; set; }
        public string transito_em { get; set; }
        public string entregue_em { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string data_agendamento { get; set; }
        public decimal valor_entrega { get; set; }
        public decimal total { get; set; }
        public decimal retirada { get; set; }
        public decimal troco { get; set; }
        public string cpf_cnpj { get; set; }
        public int status { get; set; }
        public string codigo_desconto { get; set; }
        public decimal valor_desconto { get; set; }
        public string texto_desconto { get; set; }
        public int pagamento_online { get; set; }
        public decimal valor_desconto_premio { get; set; }
        public decimal valor_desconto_entrega { get; set; }
        public decimal total_com_descontos { get; set; }
        public int agendamento { get; set; }
        public int id_meio_de_pagamento { get; set; }
        public string meio_de_pagamento { get; set; }
        public string coordenadas_cliente { get; set; }
        public endereco_de_entrega endereco_de_entrega { get; set; }
        public usuario usuario { get; set; }
        public List<item> itens { get; set; }
    }
}
