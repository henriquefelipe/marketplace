using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Food.Domain
{
    public class pedido
    {
        public pedido()
        {
            itens = new List<item>();
        }

        public int id { get; set; }
        public object clienteID { get; set; }
        public string clienteNome { get; set; }
        public string clienteEmail { get; set; }
        public string clienteTelefone { get; set; }
        public object clienteEnderecoID { get; set; }
        public string clienteLogradouro { get; set; }
        public string clienteNumero { get; set; }
        public string clienteBairro { get; set; }
        public string clienteMunicipio { get; set; }
        public string clienteUF { get; set; }
        public string clientePais { get; set; }
        public string clienteCEP { get; set; }
        public string clienteComplemento { get; set; }
        public string clientePontoReferencia { get; set; }
        public int estabelecimentoID { get; set; }
        public string estabelecimentoGuid { get; set; }
        public string estabelecimentoNome { get; set; }
        public string estabelecimentoTelefone { get; set; }
        public string estabelecimentoEndereco { get; set; }
        public string estabelecimentoLatitude { get; set; }
        public string estabelecimentoLongitude { get; set; }
        public int grupoEstabelecimentoID { get; set; }
        public object entregadorID { get; set; }
        public string entregadorTelefone { get; set; }
        public string entregadorNome { get; set; }
        public int tipo { get; set; }
        public int status { get; set; }
        public int motivoPerda { get; set; }
        public int formaPagamentoID { get; set; }
        public string motivoCancelamento { get; set; }
        public string motivoSolicitacaoCancelamento { get; set; }
        public string gatewayPagamento { get; set; }
        public string gatewayTransacaoID { get; set; }
        public string aceitoEm { get; set; }
        public string preenchidoEm { get; set; }
        public int tempoParaEntrega { get; set; }
        public string observacoes { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public decimal valorProdutos { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal valorTaxaEntrega { get; set; }
        public decimal valorTotal { get; set; }
        public decimal valorParaTroco { get; set; }
        public string cupomDesconto { get; set; }
        public object promocaoID { get; set; }
        public string concluidoEm { get; set; }
        public string canceladoEm { get; set; }
        public string solicitacaoCancelamentoEm { get; set; }
        public string emEntregaEm { get; set; }
        public string aguardandoRetiradaEm { get; set; }
        public string promocoes { get; set; }
        public string criadoEm { get; set; }
        public string atualizadoEm { get; set; }
        public List<item> itens { get; set; }
    }
}
