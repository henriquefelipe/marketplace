using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class item
    {
        public string codPedido { get; set; }
        public int sequencia { get; set; }
        public decimal quantidade { get; set; }
        public decimal vlrUnitLiq { get; set; }
        public string codProdutoPdv { get; set; }
        public string codTipoProdutoPdv { get; set; }
        public int grupoExtra { get; set; }
        public string descricao { get; set; }
        public string codUnidade { get; set; }
        public string obsItem { get; set; }
    }
}
