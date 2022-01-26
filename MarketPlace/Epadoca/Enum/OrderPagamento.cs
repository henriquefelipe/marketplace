using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Enum
{
    public static class OrderPagamentoType
    {
        public const string DINHEIRO = "DINHEIRO";
        public const string CARTAO_DEBITO = "CARTAO_DEBITO";
        public const string CARTAO_CREDITO = "CARTAO_CREDITO";
        public const string CARTAO_REFEICAO = "CARTAO_REFEICAO";
        public const string PIX = "PIX";
        public const string PIX_ONLINE = "PIX_ONLINE";
        public const string OUTROS = "OUTROS";
        public const string PIC_PAY = "PIC_PAY";
        public const string BOLETO = "BOLETO";
    }

    public static class OrderTipoPagamento
    {
        public const string ENTREGA = "Entrega";
        public const string ONLINE = "Online";
        public const string OUTRO = "Outro";
    }

    public class OrderPagamento
    {
        public string nome { set; get; }
        public int numero { get; set; }
        public string tipoPagamento { get; set; }
    }

    public static class OrderPagamentoLista
    {
        public static List<OrderPagamento> ObterLista()
        {
            var lista = new List<OrderPagamento>();
            lista.Add(new OrderPagamento { nome = "Dinheiro", numero = 1, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Visa", numero = 2, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Mastercard", numero = 3, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - ELO", numero = 4, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Diners", numero = 5, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - American Express", numero = 6, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Débito - Visa", numero = 7, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Débito - Mastercard", numero = 8, tipoPagamento = "Entrega"});
            lista.Add(new OrderPagamento { nome = "Débito - ELO", numero = 9, tipoPagamento = "Entrega"});
            lista.Add(new OrderPagamento { nome = "Refeição - Alelo", numero = 10, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Refeição - Ticket", numero = 11, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Refeição - Sodexo", numero = 12, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Boleto", numero = 13, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Aura", numero = 14, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Benes", numero = 15, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Cabal", numero = 16, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Credz", numero = 17, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Discover", numero = 18, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Good", numero = 19, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - Green", numero = 20, tipoPagamento = "Entrega"});
            lista.Add(new OrderPagamento { nome = "Débito - Hiper", numero = 21, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Hipercard", numero = 22, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - JCB", numero = 23, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Mais", numero = 24, tipoPagamento = "Entrega"});
            lista.Add(new OrderPagamento { nome = "Refeição - Maxcard", numero = 25, tipoPagamento = "Entrega"});
            lista.Add(new OrderPagamento { nome = "Alimentação - Policard", numero = 26, tipoPagamento = "Entrega"});
            lista.Add(new OrderPagamento { nome = "Crédito - Rede", numero = 27, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Soro", numero = 28, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - Vale", numero = 29, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Refeição - Verocard", numero = 30, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Refeição - VR", numero = 31, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Crédito - Beblue", numero = 32, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - Vero", numero = 34, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Refeição - Ben", numero = 35, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - Alelo", numero = 39, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - Cooper", numero = 37, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Refeição - Cooper", numero = 38, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Pagamento Online", numero = 36, tipoPagamento = "Online" });
            lista.Add(new OrderPagamento { nome = "Alimentação - Ticket", numero = 40, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - VR", numero = 41, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - BIQ", numero = 42, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Alimentação - Sodexo", numero = 43, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "A definir", numero = 99, tipoPagamento = "Outro" });
            lista.Add(new OrderPagamento { nome = "Transferência", numero = 44, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Cartão Cantina Nutri", numero = 45, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "À prazo", numero = 46, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Vale Refeição Impresso", numero = 47, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Boleto para 07 dias", numero = 48, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "PicPay", numero = 49, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Plano", numero = 51, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Pix Online", numero = 54, tipoPagamento = "Online" });
            lista.Add(new OrderPagamento { nome = "Pix Chave", numero = 53, tipoPagamento = "Outro" });
            lista.Add(new OrderPagamento { nome = "Débito - Banrisul",  numero = 55, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Faturamento", numero = 56, tipoPagamento = "Entrega"});
            lista.Add(new OrderPagamento { nome = "Le Card - Refeição", numero = 57, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Le Card - Alimentação", numero = 58, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Megavale Card - Refeição", numero = 59, tipoPagamento = "Entrega" });
            lista.Add(new OrderPagamento { nome = "Megavale Card - Alimentação",  numero = 60, tipoPagamento = "Entrega" });

            return lista;
        }

        public static string ObterPorTipo(int numero)
        {
            var pagamento = ObterLista().FirstOrDefault(f => f.numero == numero);
            if(pagamento != null)
            {
                if(pagamento.numero == 1)
                {
                    return OrderPagamentoType.DINHEIRO;
                }
                else if(pagamento.nome.Contains("Crédito"))
                {
                    return OrderPagamentoType.CARTAO_CREDITO;
                }
                else if(pagamento.nome.Contains("Débito"))
                {
                    return OrderPagamentoType.CARTAO_DEBITO;
                }
                else if (pagamento.nome.Contains("Refeição") || pagamento.nome.Contains("Alimentação"))
                {
                    return OrderPagamentoType.CARTAO_REFEICAO;
                }
                else if (pagamento.nome.Contains("Boleto"))
                {
                    return OrderPagamentoType.BOLETO;
                }
                else if (pagamento.nome.Contains("Pix") && pagamento.tipoPagamento == OrderTipoPagamento.ONLINE)
                {
                    return OrderPagamentoType.PIX_ONLINE;
                }
                else if (pagamento.nome.Contains("Pix") && pagamento.tipoPagamento == OrderTipoPagamento.ENTREGA)
                {
                    return OrderPagamentoType.PIX;
                }
                else if (pagamento.nome.Contains("PicPay"))
                {
                    return OrderPagamentoType.PIC_PAY;
                }
            }

            return OrderPagamentoType.OUTROS;
        }
    }
}
 