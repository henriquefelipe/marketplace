using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Americanas.Domain
{
    public class pedido
    {
        public pedido()
        {
            products = new List<product>();
        }

        public int id { get; set; }
        public decimal amount { get; set; }
        public string tip { get; set; }
        public decimal fee { get; set; }
        public decimal delivery_fee { get; set; }
        public string status { get; set; }
        public string type_order { get; set; }
        public string delivery_method { get; set; }
        public string created_at { get; set; }
        public string payment_method { get; set; }
        public customer customer { get; set; }
        public string deliveryman { get; set; }
        public store store { get; set; }
        public customerAddress customer_address { get; set; }
        public List<product> products { get; set; }
    }
}
