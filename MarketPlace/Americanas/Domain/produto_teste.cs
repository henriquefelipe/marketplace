using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Americanas.Domain
{
    public class produto_teste
    {
        public produto_teste()
        {
            data = new List<produto_teste_item>();
        }

        public int total { get; set; }
        public int current_page { get; set; }
        public string per_page { get; set; }
        public int total_pages { get; set; }
        public int results_from { get; set; }
        public int results_to { get; set; }

        public List<produto_teste_item> data { get; set; }
    }

    public class produto_teste_item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        public string description { get; set; }
        public int quantity { get; set; }
        public string weight { get; set; }
        public string sku { get; set; }
        public int is_promotion { get; set; }
        public object promotion_price { get; set; }
        public decimal price { get; set; }
        public string created_at { get; set; }
    }
}
