using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class order
    {
        public order() 
        {
            ProductsSold = new List<productResult>();
        }

        public string status {  get; set; }
        public string id { get; set; }
        public DateTime date { get; set; }
        public TimeSpan hour { get; set; }
        public string customer_id { get; set; }
        public decimal partial_total { get; set; }
        public decimal taxes { get; set; }
        public decimal discount { get; set; }
        public string point_sale { get; set; }
        public string shipment { get; set; }
        public decimal shipment_value { get; set; }
        public string shipment_date { get; set; }
        public string delivered { get; set; }
        public string delivered_status { get; set; }
        public string shipping_cancelled { get; set; }
        public string store_note { get; set; }
        public string customer_note { get; set; }
        public string partner_id { get; set; }
        public string discount_coupon { get; set; }
        public string client_ip { get; set; }
        public decimal payment_method_rate { get; set; }
        public string installment { get; set; }
        //public string value_1": "0.00",
        public string sending_code { get; set; }
        public string sending_date { get; set; }
        public string billing_address { get; set; }
        public string delivery_time { get; set; }
        public string payment_method_id { get; set; }
        public string payment_method { get; set; }
        public string session_id { get; set; }
        public decimal total { get; set; }
        public string payment_date { get; set; }
        public string access_code { get; set; }
        public string shipment_integrator { get; set; }
        public DateTime modified { get; set; }
        public string printed { get; set; }
        public decimal interest { get; set; }
        public decimal cart_additional_values_discount { get; set; }
        public decimal cart_additional_values_increase { get; set; }
        public string id_quotation { get; set; }
        public string estimated_delivery_date { get; set; }
        public string is_traceable { get; set; }
        public string external_code { get; set; }
        public string tracking_url { get; set; }
        public string has_payment { get; set; }
        public string has_shipment { get; set; }
        public string has_invoice { get; set; }
        public string delivery_date { get; set; }
        public decimal total_comission_user { get; set; }
        public decimal total_comission { get; set; }
        public decimal cost { get; set; }
        public string app_id { get; set; }
        public string store_segment { get; set; }
        public string payment_method_type { get; set; }
        public string partner_name { get; set; }

        public customer Customer { get; set; }
        public orderStatus OrderStatus { get; set; }
        public List<productResult> ProductsSold { get; set; }
        public List<paymentResult> Payment { get; set; }
    }
}
