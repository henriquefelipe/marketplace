using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class order
    {
        public order()
        {
            ItemOrder = new List<item>();
            PizzaOrders = new List<pizza>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string date { get; set; }
        public string updated_at { get; set; }
        public int status { get; set; }
        public decimal tax { get; set; }
        public string voucher_code { get; set; }
        public decimal voucher_discount { get; set; }
        public string payment_method { get; set; }
        public string notes { get; set; }
        public string street { get; set; }
        public string cep { get; set; }
        public string number { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string complement { get; set; }
        public string reference_point { get; set; }
        public int forma_entrega { get; set; }
        public string table_name { get; set; }
        public int order_number { get; set; }
        public decimal troco { get; set; }
        public int client_id { get; set; }
        public bool payment_online { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string cpf_in_note { get; set; }
        public bool printed { get; set; }
        public decimal total_discount { get; set; }
        public decimal taxa_extra { get; set; }
        public string taxa_extra_title { get; set; }
        public decimal sub_total { get; set; }
        public decimal total { get; set; }  
        public bool is_scheduled { get; set; }
        public string scheduled_at { get; set; }

        public fidelityProgram FidelityProgram { get; set; }
        public List<item> ItemOrder { get; set; }
        public List<pizza> PizzaOrders { get; set; }
    }
}
