using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedZap.Domain
{
    public class pedido_item_pergunta
    {
        public pedido_item_pergunta()
        {
            pedido_Items_Respostas = new List<pedido_item_resposta>();
        }

        public int per_id { get; set; }
        public string per_label { get; set; }
        public string per_titulo { get; set; }
        public string per_formato { get; set; }
        public string per_grupo { get; set; }
        public bool per_mediaponderada { get; set; }
        public int car_per_id { get; set; }
        public bool respostas { get; set; }

        public List<pedido_item_resposta> pedido_Items_Respostas { get; set; }
    }
}
