using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class produto
    {
        public produto()
        {
            Options = new List<produto_option>();
        }


        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int? calculation { get; set; }
        public decimal quantity { get; set; }
        public string category_ref { get; set; }
        public string pizza_tamanho_ref { get; set; }
        public decimal subtotal { get; set; }

        public List<produto_option> Options { get; set; }
        public List<complement_categorie> ComplementCategories { get; set; }
    }
}
