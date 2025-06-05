using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class customer
    {
        public customer()
        {
            CustomerAddresses = new List<customerAddressesResult>();
        }

        public string cnpj { get; set; }
        public string newsletter { get; set; }
        public DateTime created { get; set; }
        public string terms { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public DateTime registration_date { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string phone { get; set; }
        public string cellphone { get; set; }
        public string birth_date { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string nickname { get; set; }
        public string token { get; set; }
        public int total_orders { get; set; }
        public string observation { get; set; }
        public string type { get; set; }
        public string foreign { get; set; }
        public string company_name { get; set; }
        public string state_inscription { get; set; }
        public string reseller { get; set; }
        public decimal discount { get; set; }
        public string blocked { get; set; }
        public decimal credit_limit { get; set; }
        public string indicator_id { get; set; }
        public string profile_customer_id { get; set; }
        public string last_sending_newsletter { get; set; }
        public string last_purchase { get; set; }
        public string last_visit { get; set; }
        public string last_modification { get; set; }
        public string address { get; set; }
        public string zip_code { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string modified { get; set; }
        public string count_orders { get; set; }

        public List<customerAddressesResult> CustomerAddresses { get; set; }
    }
}
