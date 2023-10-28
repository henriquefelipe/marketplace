using System;
using System.Collections.Generic;
using System.Text;

namespace EuFalo.Domain
{
    public  class venda
    {
        public venda()
        {
            item = new List<venda_item>();
        }

        public string contatoCI { get; set; }
        public string vendaContatoCI { get; set; }
        public string contatoCPF { get; set; }
        public bool contarPontos { get; set; }
        public bool resgateAutomatico { get; set; }
        public string dataVenda { get; set; }
        public string numero { get; set; }
        public decimal valor { get; set; }
        public decimal desconto { get; set; }
        public decimal comissao { get; set; }
        public string vendedorCI { get; set; }
        public string nomeVendedor { get; set; }
        public string formaPagamentoCI { get; set; }
        public string nomeFormaPagamento { get; set; }
        public string filialCI { get; set; }
        public string filialNomeFantasia { get; set; }
        public string formaEnvioCI { get; set; }
        public string nomeFormaEnvio { get; set; }
        public decimal valorFrete { get; set; }

        public List<venda_item> item { get; set; }
    }

    public class venda_item
    {
        public string vendaContatoItemCI { get; set; }
        public string produtoCI { get; set; }
        public decimal quantidade { get; set; }
        public decimal valor { get; set; }
        public decimal desconto { get; set; }
        public decimal comissao { get; set; }
    }
 }
