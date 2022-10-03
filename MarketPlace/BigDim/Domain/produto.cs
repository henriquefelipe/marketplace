using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class produto
    {
        public int id { get; set; }
        public categoria categoria { get; set; }        
        public int? arquivoId { get; set; }
        public string urlImagem { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
        public string dataExclusao { get; set; }
        public string disponibilidade { get; set; }
        public decimal valorUnitario { get; set; }
        public bool habilitarControleEstoque { get; set; }
        public int quantidadeEstoqueDisponivel { get; set; }
        public string codigoPdv { get; set; }
        public int? ordem { get; set; }
        public int versao { get; set; }
    }
}
