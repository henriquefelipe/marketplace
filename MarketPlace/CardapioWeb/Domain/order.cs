using System;
using System.Collections.Generic;
using System.Text;

namespace CardapioWeb.Domain
{
    public class order
    {
        public order()
        {
            items = new List<item>();
            payments = new List<payment>();
            discounts = new List<discount>();
        }

        public int id {  get; set; }        
        public string created_at { get; set; }
        public int display_id { get; set; }
        public string order_type { get; set; }
        public string updated_at { get; set; }
        public int merchant_id { get; set; }
        public decimal service_fee { get; set; }
        public decimal delivery_fee { get; set; }
        public string order_timing { get; set; }        
        public string sales_channel { get; set; }
        public decimal additional_fee { get; set; }
        public decimal total {  get; set; }
        public string status { get; set; }       
        public customer customer { get; set; }
        public address delivery_address { get; set; }
        public string cancellation_reason { get; set; }

        public List<item> items { get; set; }
        public List<payment> payments { get; set; }
        public List<discount> discounts { get; set; }
    }
}
