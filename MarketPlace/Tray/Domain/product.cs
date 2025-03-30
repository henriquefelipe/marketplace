using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class product
    {
        public string product_kit_id { get; set; }
        public string product_kit_id_kit { get; set; }
        public string id_campaign { get; set; }
        public string product_id { get; set; }
        public decimal quantity { get; set; }
        public string id { get; set; }
        public string order_id { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public string virtual_product { get; set; }
        public string ean { get; set; }
        public string availability_days { get; set; }
        public string availability { get; set; }
        //public string Sku": [],
        public decimal price { get; set; }
        public decimal cost_price { get; set; }
        public decimal original_price { get; set; }
        public string weight { get; set; }
        public string weight_cubic { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string reference { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string variant_id { get; set; }
        public string additional_information { get; set; }
        public string text_variant { get; set; }
        public string warranty { get; set; }
        public string bought_together_id { get; set; }
        public string ncm { get; set; }
        public string included_items { get; set; }
        public string release_date { get; set; }
        public string commissioner_value { get; set; }
        public decimal comissao { get; set; }
        public string is_giveaway_by_coupon { get; set; }
        public string is_giveaway { get; set; }
    }
}
