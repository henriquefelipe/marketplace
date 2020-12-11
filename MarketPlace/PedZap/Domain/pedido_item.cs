using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedZap.Domain
{
    public class pedido_item
    {
        public pedido_item()
        {
            pedido_Items_Perguntas = new List<pedido_item_pergunta>();
        }

        public int ite_id { get; set; }
        public int? ite_codigo { get; set; }
        public string ite_sku { get; set; }
        public string ite_titulo { get; set; }
        public decimal ite_preco { get; set; }
        public decimal ite_quantidade { get; set; }
        public int car_ite_id { get; set; }
        public bool perguntas { get; set; }

        public List<pedido_item_pergunta> pedido_Items_Perguntas { get; set; }
    }
}
