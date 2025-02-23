using System;
using System.Collections.Generic;
using System.Text;

namespace VMarket.Domain
{
    public class pedido_item_retorno
    {
        public int current_page {  get; set; }
        public List<pedido_item> data { get; set; }
    }

    public class pedido_item_retorno_main
    {
        public pedido_item_retorno itens { get; set; }
    }
}
