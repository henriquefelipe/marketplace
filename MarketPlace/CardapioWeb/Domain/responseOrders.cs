using System;
using System.Collections.Generic;
using System.Text;

namespace CardapioWeb.Domain
{
    public class responseOrders
    {
        public int id {  get; set; }
        public string status { get; set; }
        public string order_type { get; set; }
        public string order_timing { get; set; }
        public string sales_channel { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
