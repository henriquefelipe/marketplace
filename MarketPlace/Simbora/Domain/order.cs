using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Domain
{
    public class order
    {
        public order()
        {
            items = new List<item>();
        }

        public string external_id { get; set; }
        public decimal total { get; set; }
        public order_origin origin { get; set; }
        public order_destination destination { get; set; }
        public order_payFormat payFormat { get; set; }
        public string error { get; set; }
        public bool check_store { get; set; }
        public string observation { get; set; }
        public string client_name { get; set; }
        public string client_phone { get; set; }
        public string status_url { get; set; }
        public string cancel_url { get; set; }
        public string iD_erp_cliente { get; set; }
        public string iD_integrador { get; set; }
        public string external_localizer { get; set; }

        public List<item> items { get; set; }
    }

    public class order_origin
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }

    public class order_destination
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string cep { get; set; }
        public string reference { get; set; }
        public string external_id { get; set; }
    }

    public class order_payFormat
    {
        public string method { get; set; }
        public decimal change { get; set; } //Caso o método escolhido seja ‘money’ esse campo pode ser utilizado para mostrar o valor do troco.

    }
}
