using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class order
    {
        public order()
        {
            pagamentos = new List<order_payment>();
        }

        public string codPedido { get; set; }
        public string idPedidoCurto { get; set; }
        public int idFrn { get; set; }
        public string dataEntrega { get; set; }
        public string dataPedido { get; set; }
        public string dataAgendamento { get; set; }
        public bool togo { get; set; }
        public decimal vlrTaxa { get; set; }
        public decimal vlrPratos { get; set; }
        public decimal vlrTroco { get; set; }
        public decimal vlrDesconto { get; set; }
        public decimal vlrTotal { get; set; }
        public string obsPedido { get; set; }
        public string condicaoPgto { get; set; }
        public string formaPgto { get; set; }
        public string codCupom { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string dddTelefone { get; set; }
        public string numTelefone { get; set; }
        public string logradouro { get; set; }
        public string logradouroNum { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public int minEspera { get; set; }
        public int maxEspera { get; set; }
        public bool clienteNovo { get; set; }
        public string cpfCliente { get; set; }
        public string cpfNota { get; set; }
        public string status { get; set; }
        public List<order_payment> pagamentos { get; set; }

    }
}
