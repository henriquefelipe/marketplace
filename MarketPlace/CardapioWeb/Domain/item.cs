using System;
using System.Collections.Generic;
using System.Text;

namespace CardapioWeb.Domain
{
    public class item
    {
        public item()
        {
            options = new List<option>();
        }

        public string kind { get; set; }
        public string name { get; set; }
        public int order_item_id { get; set; }
        public string status { get; set; }
        public int? item_id { get; set; }
        public decimal quantity { get; set; }
        public decimal unit_price { get; set; }
        public string observation { get; set; }
        public decimal total_price { get; set; }
        public string external_code { get; set; }

        public List<option> options { get; set; }
    }

    public class option
    {
        public string name { get; set; }
        public decimal quantity { get; set; }
        public int option_id { get; set; }
        public decimal unit_price { get; set; }
        public string external_code { get; set; }
        public int option_group_id { get; set; }
        public string option_group_name { get; set; } // Tamanho, Molho
    }
}
