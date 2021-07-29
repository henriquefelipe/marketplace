using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class payment
    {
        public payment_charges charges { get; set; }
    }

    public class payment_charges
    {
        public currency total { get; set; }
        public currency sub_total { get; set; }
        public currency tax { get; set; }
        public currency total_fee { get; set; }
        public currency total_fee_tax { get; set; }
        public currency delivery_fee { get; set; }
        public currency delivery_fee_tax { get; set; }
        public currency small_order_fee { get; set; }       
    }
  
}
