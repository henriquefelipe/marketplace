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
        public string @event { get; set; }
        public decimal? id { get; set; }
        public decimal? order_id { get; set; }
        public string cancellation_reason_id { get; set; }
        public string cancellation_notes { get; set; }
        public string cancellation_notes_to_client { get; set; }
        public string pos_user_id { get; set; }
    }
}
