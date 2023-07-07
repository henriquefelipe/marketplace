using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPedido.Domain
{
    public class order
    {
        public order()
        {
            history = new List<order_history>();
        }

        public int order_no { get; set; }
        public string notes { get; set; }
        public bool need_change { get; set; }
        public string payment_method_operation { get; set; }
        public string restaurant_id { get; set; }
        public bool car_takeout { get; set; }
        //public payments": [],
        public string created_at { get; set; }
        public string source { get; set; }
        public bool is_table { get; set; }
        public string uuid { get; set; }
        public string client_id { get; set; }
        public decimal total_net_value { get; set; }
        public string order_status { get; set; }
        public decimal total { get; set; }
        public string card_payment_method { get; set; }
        public string transmission_list_uuid { get; set; }
        public string updated_at { get; set; }
        public string delivery_type { get; set; }
        public int id { get; set; }
        public string table { get; set; }
        public string payment_method { get; set; }
        public string external_source { get; set; }
        public string delivery_fee_discount_type { get; set; }
        public decimal? delivery_fee_discount_value { get; set; }
        public decimal? delivery_fee_net_value { get; set; }
        public string online_payment_reference { get; set; }
        public int cashier_id { get; set; }
        public decimal change { get; set; }
        public string payment_status { get; set; }
        public int points_earned { get; set; }
        public string coordinates { get; set; }
        public decimal service_fee { get; set; }
        public string card_type { get; set; }
        public string phone { get; set; }
        public decimal? payment_method_operation_value { get; set; }
        public string name_ci { get; set; }
        public string name { get; set; }
        public order_client client { get; set; }
        public List<order_items> items { get; set; }
        public List<order_history> history { get; set; }
        public string car_plate { get; set; }
        public string car_model_color { get; set; }
    }
}
