using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Domain
{
    public class order
    {
        public order()
        {
            itens = new List<item>();
        }

        public string guid { get; set; }
        public string numero { get; set; }
        public string dataCadastro { get; set; }
        public string endereco { get; set; }
        public string enderecoSiglaEstado { get; set; }
        public string enderecoCidade { get; set; }
        public string enderecoBairro { get; set; }
        public string enderecoLogradouro { get; set; }
        public string enderecoNumero { get; set; }
        public string enderecoCep { get; set; }
        public string entrega { get; set; }
        public int tipoEntrega { get; set; }
        public string entregador { get; set; }
        public string valorTotal { get; set; }
        public string valorSubTotal { get; set; }
        public string valorTroco { get; set; }
        public string valorDesconto { get; set; }
        public string usuarioConsumidorCodigo { get; set; }
        public string usuarioConsumidorNome { get; set; }
        public string usuarioConsumidorEmail { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string formaPagamentoNome { get; set; }
        public string formaPagamentoTipo { get; set; }
        public string formaPagamentoIcone { get; set; }
        public bool isNotaFiscalPaulista { get; set; }
        public string isNotaFiscalPaulistaString { get; set; }
        public string cpf { get; set; }
        public string valorPagamento { get; set; }
        public string valorFrete { get; set; }
        public string tempoRestante { get; set; }
        public string status { get; set; }
        public string statusNumero { get; set; }
        public string agendamentoData { get; set; }
        public string agendamentoDataString { get; set; }
        public string agendamentoDataHumanize { get; set; }
        public string tipoPedido { get; set; }
        public string voucher { get; set; }
        public string tipoEntregaLogistica { get; set; }
        public string clienteNomeFantasia { get; set; }

        public List<item> itens { get; set; }
    }
}
