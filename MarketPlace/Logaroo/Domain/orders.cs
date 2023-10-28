using System;
using System.Collections.Generic;

namespace Logaroo.Domain
{
    public class orders
    {
        public ordersData data { get; set; }
    }

    public class orderresult
    {
        public ordersItems data { get; set; }
    }

    public class ordersData
    {        
        public List<ordersItems> items { get; set; }
        public int totals { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
    }

    public class ordersItems
    {
        public int id { get; set; }
        public ordersItemsAddress address { get; set; }
        public ordersItemsCustomer customer { get; set; }
        public ordersBiker biker { get; set; }
        public string start_delivery { get; set; }
        public string delivery_time { get; set; }
        public List<ordersItemsItems> items { get; set; }
        public string observation { get; set; }
        //public string justifications { get; set; }
        public ordersItemsPayment payment { get; set; }
        public ordersItemsMerchant merchant { get; set; }

        public string reference_id { get; set; }
        public string reference_name { get; set; }       
        public string status { get; set; }
        public decimal? store_delivery_rate { get; set; }
        public decimal? store_delivery_dynamic_rate { get; set; }
        public decimal? store_delivery_pick { get; set; }
        public decimal? store_delivery_total { get; set; }
        public decimal? agent_dynamic_rate { get; set; }
        public decimal? agent_pick { get; set; }
        public decimal? agent_total { get; set; }
        public decimal subtotal { get; set; }
        public decimal total_price { get; set; }
        public string birth { get; set; }
        public string created_at { get; set; }
        public string delivered_at { get; set; }
        public string updated_at { get; set; }    
        public router routes { get; set; }
    }

    public class ordersItemsAddress
    {
        public int id { get; set; }
        public string neighborhood { get; set; }
        public string zipcode { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string landmark { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class ordersItemsCustomer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string identification_number { get; set; }
    }

    public class ordersItemsItems
    {
        public int seq { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string observation { get; set; }
        public decimal quantity { get; set; }
    }

    public class ordersItemsPayment
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string reference_id { get; set; }
    }

    public class ordersItemsMerchant
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public ordersItemsMerchantMall mall { get; set; }
    }

    public class ordersItemsMerchantMall
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class ordersBiker
    {
        public int id { get; set; }
        public string android { get; set; }
        public string app { get; set; }
        public int? battery { get; set; }
        public string first_name { get; set; }
        public bool has_route { get; set; }
        public string last_name { get; set; }
        public long? lat { get; set; }
        public long? lng { get; set; }
    }
}

