using System;
using System.Collections.Generic;
using System.Text;

namespace Woocommerce.Domain
{
    public class order
    {
        public order()
        {
            meta_data = new List<meta_data>();
        }

        public int id { get; set; }
        public int parent_id { get; set; }
        public string status { get; set; }
        public string currency { get; set; }
        public string version { get; set; }
        public bool prices_include_tax { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
        public string discount_total { get; set; }
        public string discount_tax { get; set; }
        public string shipping_total { get; set; }
        public string shipping_tax { get; set; }
        public string cart_tax { get; set; }
        public string total { get; set; }
        public string total_tax { get; set; }
        public int customer_id { get; set; }
        public string order_key { get; set; }

        public string payment_method { get; set; }
        public string payment_method_title { get; set; }
        public string transaction_id { get; set; }
        public string customer_ip_address { get; set; }
        public string customer_user_agent { get; set; }
        public string created_via { get; set; }
        public string customer_note { get; set; }
        public string date_completed { get; set; }
        public string date_paid { get; set; }
        public string cart_hash { get; set; }
        public string number { get; set; }

        public string payment_url { get; set; }
        public bool is_editable { get; set; }
        public bool needs_payment { get; set; }
        public bool needs_processing { get; set; }
        public string date_created_gmt { get; set; }
        public string date_modified_gmt { get; set; }
        public string date_completed_gmt { get; set; }
        public string date_paid_gmt { get; set; }
        public string currency_symbol { get; set; }

        public billing billing { get; set; }
        public shipping shipping { get; set; }
        public List<meta_data> meta_data { get; set; }
        public List<item> line_items { get; set; }
    }
}
