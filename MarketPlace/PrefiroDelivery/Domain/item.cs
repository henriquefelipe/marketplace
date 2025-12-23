using System;
using System.Collections.Generic;
using System.Text;

namespace PrefiroDelivery.Domain
{
    public class item
    {
        public int produto_id { get; set; }
        public string nome { get; set; }
        public string quantidade { get; set; }
        public string valor_unitario { get; set; }
        public string valor_total { get; set; }
        public string descricao { get; set; }
        public int? sku { get; set; }
        public string observacao { get; set; }
        public string taxa_embalagem { get; set; }
        public bool isPizza { get; set; }
        public List<complemento> complementos { get; set; }
        public string tamanho { get; set; }
        public int tamanho_id { get; set; }
        public List<opcoes> sabores { get; set; }
        public List<opcoes> opcoes { get; set; }
    }

    public class opcoes
    {
        public int? sku { get; set; }
        public string nome { get; set; }
        public string valor { get; set; }
        public int opcao_id { get; set; }
        public string opcao { get; set; }

        public int quantidade { get; set; }
    }

    public class complemento
    {
        public int? sku { get; set; }
        public string nome { get; set; }
        public decimal valor { get; set; }
        public decimal valor_unitario { get; set; }       
        public string quantidade { get; set; }
        public int quantidade_total { get; set; }
        public string composicao { get; set; }
    }
}
