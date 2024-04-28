using System;
using System.Collections.Generic;
using System.Text;

namespace SelfBuyMe.Domain
{
    public class order
    {
        public order()
        {
            payment = new List<payment>();
            order_details = new List<order_details>();
        }

        public int id { get; set; }
        public string uuid { get; set; }
        public decimal total_price { get; set; }
        public decimal subtotal { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }
        public decimal additional { get; set; }
        public string created_at { get; set; }
        public order_status order_status { get; set; }
        public order_customer customer { get; set; }
        public List<payment> payment { get; set; }
        public point_sale point_sale { get; set; }
        public List<order_details> order_details { get; set; }
    }

    public class order_status
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class order_customer
    {

        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string document { get; set; }
        public string birthday { get; set; }

    }
}
