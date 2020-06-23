using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logaroo.Domain
{
    public class order
    {        
        public string reference_id { get; set; }
        public string birth { get; set; }
        public string reference_name { get; set; }
        public string origin { get; set; }
        public string merchant_id { get; set; }
        public string city { get; set; }
        public string customer_email { get; set; }
        public string customer_id_number { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string neighborhood { get; set; }
        public string number { get; set; }        
        public string payment_code { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public decimal sub_total { get; set; }
        public decimal total_price { get; set; }
        public string zipcode { get; set; }
        public string status { get; set; }
        public string items { get; set; }

        public void addItems(List<orderitem> items)
        {
            this.items = JsonConvert.SerializeObject(items);
        }
    }
   
    public class orderitem
    {
        public int seq { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string observation { get; set; }
        public decimal quantity { get; set; }
    }
}
