using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class bill
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public int? user_id { get; set; }
        public decimal price { get; set; }
        public decimal? discount { get; set; }
        public decimal? change { get; set; }
        public int table_id { get; set; }
        public bool tip { get; set; }

        public string created_at { get; set; }
        public string updated_at { get; set; }        

        public bill_user user { get; set; }
        public bill_table table { get; set; }
    }

    public class bill_user
    {
        public int id { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }

    public class bill_table
    {
        public int id { get; set; }
        public string number { get; set; }
    }
}
