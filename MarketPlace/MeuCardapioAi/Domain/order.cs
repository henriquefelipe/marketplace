using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class order
    {
        public cliente cliente { get; set; }
        public operador operador { get; set; }
        public List<item> itens { get; set; }
        public List<pagamento> pagamentos { get; set; }
        public endereco endereco { get; set; }
        public string codigo { get; set; }
        public string horario { get; set; }
        public string horarioEntregaAgendada { get; set; }
        public int statusOrdem { get; set; }
        public decimal subvalor { get; set; }
        public decimal desconto { get; set; }
        public decimal taxaEntrega { get; set; }
        public decimal total { get; set; }
        public bool pago { get; set; }
        public bool cancelado { get; set; }
        public bool podeEditar { get; set; }
        public bool finalizado { get; set; }
        public string formaDeEntrega { get; set; }
        public bool aguardandoPagamentoOnline { get; set; }
        public bool foiPagoOnline { get; set; }
        public string status { get; set; }       
        public bool temCashback { get; set; }
        public bool retirar { get; set; }        
    }
}
