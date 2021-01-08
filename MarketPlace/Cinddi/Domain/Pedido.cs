using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinddi.Domain
{
    public class Pedido
    {
        public string SEQ { get; set; }
        public string NUMEROPEDIDO { get; set; }
        public string DATAHORA { get; set; }
        public string NOME { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CEP { get; set; }
        public string CIDADE { get; set; }
        public string ESTADO { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string OBSERVACAO { get; set; }
        public string FORMAPAGAMENTO { get; set; }
        public decimal TOTALCONTA { get; set; }
        public decimal TROCOPARA { get; set; }
        public decimal VALORFRETE { get; set; }
        public decimal ACRESCIMO { get; set; }
        public string APPORIGEM { get; set; }
        public string TELEFONE { get; set; }

        public List<Item> Produtos { get; set; }
    }
}
