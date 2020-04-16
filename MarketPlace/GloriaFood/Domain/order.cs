using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class order
    {
        public int id { get; set; }
        public int api_version { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string missed_reason { get; set; }
        public int persons { get; set; }
        public string source { get; set; }
        public string payment { get; set; }
        public string accepted_at { get; set; }
        public string fulfill_at { get; set; }
        public string updated_at { get; set; }
        public bool for_later { get; set; }
        public string instructions { get; set; }
        public int restaurant_id { get; set; }
        public int company_account_id { get; set; }
        public string restaurant_name { get; set; }
        public string restaurant_phone { get; set; }
        public string restaurant_country { get; set; }
        public string restaurant_state { get; set; }
        public string restaurant_city { get; set; }
        public string restaurant_zipcode { get; set; }
        public string restaurant_street { get; set; }
        public string restaurant_latitude { get; set; }
        public string restaurant_longitude { get; set; }
        public string restaurant_timezone { get; set; }
        public string restaurant_key { get; set; }
        public string restaurant_token { get; set; }
        public string currency { get; set; }
        public int client_id { get; set; }
        public string client_first_name { get; set; }
        public string client_last_name { get; set; }
        public string client_email { get; set; }
        public string client_phone { get; set; }
        public string client_address { get; set; }
        public client_address_parts client_address_parts { get; set; }
        public bool pin_skipped { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public decimal total_price { get; set; }
        public decimal sub_total_price { get; set; }
        public string tax_type { get; set; }
        public decimal tax_value { get; set; }
        public string tax_name { get; set; }
        public List<taxlist> tax_list { get; set; }
        public List<int> coupons { get; set; }
        public string reference { get; set; }
        public List<orderitem> items { get; set; }
    }
}
