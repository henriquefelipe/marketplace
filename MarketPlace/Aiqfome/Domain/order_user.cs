using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order_user
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string mobile_phone { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public int order_count { get; set; }
        public string document_receipt { get; set; }
        public order_user_address address { get; set; }
    }

    public class order_user_address
    {
        public string street_name { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string reference { get; set; }
        public string phone { get; set; }
        public string mobile_phone { get; set; }
        public string neighborhood_name { get; set; }
        public string city_name { get; set; }
        public string state_uf { get; set; }
    }
}
