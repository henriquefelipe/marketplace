using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Food.Domain
{
    public class item
    {
        public item()
        {
            modificadores = new List<modificador>();
        }

        public string codigoPDV { get; set; }
        public int id { get; set; }
        public int catalogoItemID { get; set; }
        public int pedidoID { get; set; }
        public string nome { get; set; }
        public string observacao { get; set; }
        public string cupom { get; set; }
        public int tipo { get; set; }
        public decimal valorTotal { get; set; }
        public decimal desconto { get; set; }
        public decimal preco { get; set; }
        public decimal quantidade { get; set; }
        public string criadoEm { get; set; }
        public string atualizadoEm { get; set; }
        public List<modificador> modificadores { get; set; }
    }
}
