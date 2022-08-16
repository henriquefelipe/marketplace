using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class bill
    {
        public string status { get; set; }
        public string payment_method { get; set; }
        public int id { get; set; }
        public int bill_status_id { get; set; }
        public int? payment_method_id { get; set; }
        public string waiter_id { get; set; }
        public int price { get; set; }
        public int? change { get; set; }
        public int? discount { get; set; }
        public bool tip { get; set; }
        public string tip_value { get; set; } // comissão do garçom
        public bool? created_by_waiter { get; set; }
        public bool? created_by_pdv { get; set; }
        public string created_at { get; set; }
        public string update_at { get; set; }

        public bill_table table { get; set; }
        public bill_user user { get; set; }
    }

    public class bill_table
    {
        public int id { get; set; }
        public string number { get; set; }
        public bool? is_blocked { get; set; }
    }

    public class bill_user
    {
        public string name { get; set; }
        public int id { get; set; }
    }
}
