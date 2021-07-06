using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class order
    {
        public int id { get; set; }
        public rating rating { get; set; }
        public externalVendors externalVendors { get; set; }
        public bool delivery { get; set; }
        public bool canceled { get; set; }
        public bool scheduled { get; set; }
        public int network { get; set; }
        public int sequential { get; set; }
        public store store { get; set; }
        public user user { get; set; }
        public address address { get; set; }
        public decimal discount { get; set; }
        public decimal subtotal { get; set; }
        public decimal deliveryTax { get; set; }
        public string date { get; set; }
        public string document { get; set; }
        public decimal change { get; set; }
        public string source { get; set; }
        public List<status> status { get; set; }
        public decimal total { get; set; }
        public payment payment { get; set; }
        public string scheduledDate { get; set; }
        public List<product> products { get; set; }
    }
}
