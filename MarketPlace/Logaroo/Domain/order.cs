using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logaroo.Domain
{
    public class order
    {  
        public order()
        {
            items = new List<orderitem>();
        }

        public string reference_id { get; set; }        
        public string birth { get; set; }
        public int sale_channel { get; set; }
        public int? bag_id { get; set; }
        public int? destiny { get; set; }
        public string origin { get; set; }
        public string merchant_id { get; set; }        
        public string customer_email { get; set; }
        public string customer_id_number { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string neighborhood { get; set; }
        public string number { get; set; }        
        public string payment_code { get; set; }
        public string complement { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string landmark { get; set; }
        public string zipcode { get; set; }
        public decimal sub_total { get; set; }
        public decimal total_price { get; set; }
        
        public string status { get; set; }
        public string type { get; set; }
        public List<orderitem> items { get; set; }

        /// <summary>
        /// Data de agendamento do pedido: pedidos agendados devem ser enviados com status coletado (1)
        /// </summary>
        public string delivery_forecast { get; set; }

        public string observation { get; set; }
        public string justification_content { get; set; }

        public order_origin_data origin_data { get; set; }

    }
   
    public class orderitem
    {
        public orderitem()
        {
            subitems = new List<ordersubitem>();
        }

        public int seq { get; set; }
        public string cod { get; set; }
        public string name { get; set; }
        public string obs { get; set; }
        public decimal quantity { get; set; }

        public List<ordersubitem> subitems { get; set; }
    }

    public class ordersubitem
    {        
        public string cod { get; set; }
        public string name { get; set; }
        public string obs { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
    }

    public class order_origin_data
    {
        public string origin_id { get; set; }
        public string collect_code { get; set; }
    }
}
