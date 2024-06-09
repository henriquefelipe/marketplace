using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Domain
{
    public class order_mercadoo_status
    {
        public order_mercadoo_status_data data { get; set;}
    }

    public class order_mercadoo_status_data
    {
        public order_mercadoo_status_data()
        {
            payments = new List<order_mercadoo_status_data_payment>();
        }

        public bool status { get; set;}
        public string finished_at { get; set;}
        public string uuid { get; set;}
        public List<order_mercadoo_status_data_payment> payments { get; set;}
    }

    public class order_mercadoo_status_data_payment
    {
        public int id { get; set;}
        public string slug { get; set;}
        public string name { get; set; }
        public decimal total { get; set;}
    }
}
