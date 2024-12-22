using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Domain
{
    public  class order_orders_destiny
    {
        public int? id {  get; set; }
        public string name { get; set; }
        public order_orders_destiny_floor floor { get; set; }
        public string table_number { get; set; }
    }

    public class order_orders_destiny_floor
    {
        public int? id { get; set; }
        public string name { get; set; }
    }
}
