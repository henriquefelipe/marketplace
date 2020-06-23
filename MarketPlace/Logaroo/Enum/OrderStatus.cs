using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Enum
{
    public static class OrderStatus
    {
        public const string PedidoFoiCancelado = "0";
        public const string PedidoFoiCapturado = "1";
        public const string PedidoAguardandoModeracao = "2";
        public const string PedidoEmProducao = "3";
        public const string PedidoProntoParaColeta = "4";
        public const string PedidoColetado = "5";
        public const string PedidoSaiuParaEntrega = "6";
        public const string PedidoChegouAoCliente = "7";
        public const string PedidoEntregueAoCliente = "8";
        public const string PedidoComprovanteDePagamentoEntregueAoLojista = "9";
        public const string PedidoComProblema = "10";
        public const string PedidoForaDaAreaDeCobertura = "10A";
        public const string PedidoEnderecoNaoEncontrado = "10B";
        public const string PedidoDestinatárioAusente = "10C";
        public const string PedidoDestinatárioRecusouReceber = "10D";
        public const string PedidoProblemaNoPagamento = "10E";
        public const string PedidoPedidoErrado = "10F";
        public const string PedidoImpossibilitadoDeDevolverComprovantes = "10G";
        public const string PedidoEntregueNoBalcao = "11";

    }
}
