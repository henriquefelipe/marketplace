using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Domain
{
    public class item
    {
        public item()
        {
            complementoL = new List<item>();
        }

        public int codigo { get; set; }
        public string guid { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int quantidade { get; set; }
        public decimal valor { get; set; }
        public string categoria { get; set; }
        public int tipoCategoria { get; set; }
        public string sku { get; set; }
        public string observacaoProduto { get; set; }
        public bool isApartir { get; set; }
        public List<item> complementoL { get; set; }
        public int tipoValoracao { get; set; }
        public decimal quantidadeValoracaoUnitario { get; set; }
        public string quantidadeValoracao { get; set; }
        public decimal totalComplemento { get; set; }
        public decimal total { get; set; }
        public string nomeExibicaoTela { get; set; }
        public string nomeExibicaoTelaSku { get; set; }
    }
}
