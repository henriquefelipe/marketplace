using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class pedido_valor
    {
        public pedido_valor_comentario comentario { get; set; }
        public pedido_valor_pagamento pagamento { get; set; }
        public pedido_valor_cupom cupom { get; set; }
        public decimal taxa { get; set; }
        public pedido_valor_retirada retirada { get; set; }
        public pedido_valor_troco troco { get; set; }
        public decimal total { get; set; }
    }
}
