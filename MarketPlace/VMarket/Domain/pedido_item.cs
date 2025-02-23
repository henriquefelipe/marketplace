using System;
using System.Collections.Generic;
using System.Text;

namespace VMarket.Domain
{
    public class pedido_item
    {
        public int id_pedido_item {  get; set; }
        public int id_pedido { get; set; }
        public int id_produto { get; set; }
        public int id_produto_sisfood_cotacao { get; set; }
        public decimal preco { get; set; }
        public decimal quantidade { get; set; }
        public int fl_alterado { get; set; }
        public decimal? total { get; set; }
        //"comentario": null,
        //"comentario_avaliacao": null,
        //"avaliacao": null,
        public int id_pedido_item_status { get; set; }
        public string dt_alteracao { get; set; }
        public string nome_cotacao { get; set; }
        public string marca_cotacao { get; set; }
        public string gramatura_cotacao { get; set; }
        public decimal preco_cotacao { get; set; }
        public int id_produto_cotacao { get; set; }
    }
}
