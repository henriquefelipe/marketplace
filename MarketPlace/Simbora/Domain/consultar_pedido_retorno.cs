using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Domain
{
    public class consultar_pedido_retorno
    {
        public string status { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public consultar_pedido_retorno_data data { get; set; }
    }

    public class consultar_pedido_retorno_data
    {
        public string control_number { get; set; }
        public decimal distance { get; set; }
        public string external_id { get; set; }
        public string orderId { get; set; }
        public string status { get; set; }
        public decimal time { get; set; }
        public string driver_name { get; set; }
    }
}
