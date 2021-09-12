using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class item : item_base
    {        
        public string instance_id { get; set; }
        public string eater_id { get; set; }
        public string special_instructions { get; set; }
    }

    public class item_price
    {
        public currency unit_price { get; set; }
        public currency total_price { get; set; }
        public currency base_unit_price { get; set; }
        public currency base_total_price { get; set; }
    }
}
