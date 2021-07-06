using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class item_produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal? preco { get; set; }
        public string descricao { get; set; }
        public string mensagemPedido { get; set; }
        public string imagens { get; set; }
        //public string empresa { get; set; }
        public bool? exibirNoSite { get; set; }
        public int disponibilidade { get; set; }
        public bool? exibirPrecoSite { get; set; }
        public item_produto_categoria categoria { get; set; }
        public string tipoDeVenda { get; set; }
        public item_medida unidadeMedida { get; set; }
        public decimal? valorInicial { get; set; }
        public string incremento { get; set; }
        public bool disponivelParaDelivery { get; set; }
        public bool disponivelNaMesa { get; set; }
        public int qtdeMinima { get; set; }
        //"camposAdicionais": [],
        //"horarios": [],
        public string tipo { get; set; }
        public bool temEstoque { get; set; }
        public int ordem { get; set; }
    }
}
