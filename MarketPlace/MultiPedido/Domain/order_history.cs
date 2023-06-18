using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Domain
{
    public class order_history
    {
        public string updated_at { get; set; } 
        public string created_at { get; set; }
        public string source { get; set; }
        public int id { get; set; }
        //public string event": "CREATED",
        public int order_id { get; set; }
    }
}
