using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class pedido
    {
        public int id { get; set; }
        public empresa empresa { get; set; }
        public cliente cliente { get; set; }
        public enderecoEntrega enderecoEntrega { get; set; }
        public string dataHora { get; set; }
        public string status { get; set; }
        public string formaPagamento { get; set; }
        public decimal valorFrete { get; set; }
        public decimal valorTroco { get; set; }
        public decimal subTotal { get; set; }
        public decimal valorTotal { get; set; }
        public string motivoRecusaCancelamento { get; set; }
        public string tipoRetiradaProduto { get; set; }
        public string token { get; set; }
        public string transacao { get; set; }
        public decimal valorTrocoCliente { get; set; }
        public string ultimaAlteracaoStatus { get; set; }
        public string estimativaEntrega { get; set; }
        public int? tempoEntregaMinutos { get; set; }
        public string notificacaoWhatsEnviada { get; set; }
        public string bandeiraTransacao { get; set; }
        public string bandeiraAdicional { get; set; }
        public decimal cupomDesconto { get; set; }
        public decimal? valorDesconto { get; set; }
        public string tipoDesconto { get; set; }
        public string conta { get; set; }
        public string codigoResgateFidelizacao { get; set; }
        public string tokenFidelizacao { get; set; }
        public decimal receberCliente { get; set; }
        public int qtdePedidos { get; set; }
        public string indicacaoId { get; set; }
    }
}
