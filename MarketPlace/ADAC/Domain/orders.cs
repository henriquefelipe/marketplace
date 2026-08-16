using System;
using System.Collections.Generic;
using System.Text;

namespace ADAC.Domain
{
    public class order_retorno
    {
       public List<orders_retorno> orders { get; set; }
    }

    public class orders_retorno
    {
        public order order { get; set; }
        public string status { get; set; }
        public DateTime receivedAt { get; set; }
    }
}
