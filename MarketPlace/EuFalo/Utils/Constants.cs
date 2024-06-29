using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuFalo.Utils
{
    public static class Constants
    {
        public const string URL_BASE = "https://api.eufalo.com/";

        public const string URL_LOGIN = "Login/GetToken";
        public const string URL_CATEGORIA_LISTA = "api/v2/produtocategoria/salvar/lista";
        public const string URL_PRODUTO_LISTA = "api/v2/produto/salvar/lista";
        public const string URL_FORMAPAGAMENTO = "api/FormaPagamento";
        public const string URL_VENDEDOR = "api/Vendedor";
        public const string URL_CONTATO_SALVAR = "api/v2/contato/salvar/item";
        public const string URL_VENDA = "api/v2/vendacontato/salvar/item";
        public const string URL_CONSULTA_SALDO = "api/programafidelidade/consultarSaldoCashbackInstantaneo";
        public const string URL_BAIXAR_VOUCHER_INSTANTANEO = "api/programafidelidade/baixarvoucherCashbackInstantaneo/item";

        public const string URL_RESGATE_CASHBACK = "api/programafidelidade/resgatecashback/confirmar/item";
        public const string URL_BAIXAR_VOUCHER_META = "api/programafidelidade/baixarvoucher/item";

        public const string URL_LISTAR_POR_CPF = "api/programafidelidade/resgatecashback/listarPorCpf";
        public const string URL_CONSULTAR_SALDO_MENSAGEM = "api/Contato/ConsultarSaldoMensagem";
    }
}
