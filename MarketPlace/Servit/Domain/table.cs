using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class table
    {        
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public string number { get; set; }
        public string code { get; set; }
        public bool is_blocked { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string deleted_at { get; set; }
        public string old_table { get; set; }
        public string new_table { get; set; }

        public bool comanda { get; set; }
        public string comanda_number { get; set; }
    }
}
