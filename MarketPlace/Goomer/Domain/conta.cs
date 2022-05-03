using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Domain
{
    public class conta
    {
        public conta()
        {
            products = new List<conta_produto>();
        }

        public string status { get; set; }
        public string externalId { get; set; }
        public decimal total { get; set; }
        public decimal subtotal { get; set; }
        public decimal service { get; set; }
        public decimal discount { get; set; }
        public string table { get; set; }
        public string tab { get; set; }

        public List<conta_produto> products { get; set; }
    }

    public class conta_produto
    {
        public conta_produto()
        {
            extras = new List<conta_produto_extra>();
        }

        public string code { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public string type { get; set; }
        public string date { get; set; }
        public List<string> observations { get; set; }
        public List<conta_produto_extra> extras { get; set; }
    }

    public class conta_produto_extra
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
    }
}
