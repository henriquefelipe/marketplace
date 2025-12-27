using System;
using System.Collections.Generic;
using System.Text;

namespace PrefiroDelivery.Domain
{
    public class pedido
    {
        public int id { get; set; }
        public string data { get; set; }
        public bool entrega { get; set; }
        public string data_hora_entrega { get; set; }
        public string observacao { get; set; }
        public string valor { get; set; }
        public string troco { get; set; }
        public string valor_acompanhamentos { get; set; }
        public string taxa_entrega { get; set; }
        public string valor_pedido { get; set; }
        public string desconto { get; set; }
        public string total { get; set; }
        public string cpf_cnpj_nota { get; set; }
        public bool pago { get; set; }
        public string cupom { get; set; }
        public cliente cliente { get; set; }
        //public Estabelecimento estabelecimento { get; set; }
        public status status { get; set; }
        public metodo_pagamento metodo_pagamento { get; set; }
        public endereco endereco { get; set; }
        public List<item> itens { get; set; }
        public DateTime cadastrado { get; set; }
        public DateTime atualizado { get; set; }
    }
}
