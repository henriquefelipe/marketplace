using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain
{
    public class pizza
    {
        public pizza()
        {
            PizzaTamanho = new List<pizza_complemento>();
            PizzaSabor = new List<pizza_complemento>();
        }

        public int quantity { get; set; }
        public decimal total_un { get; set; }
        public string notes { get; set; }
        public bool pizza_maior_valor { get; set; }
        public string category { get; set; }

        public List<pizza_complemento> PizzaTamanho { get; set; }
        public List<pizza_complemento> PizzaSabor { get; set; }
    }

    public class pizza_complemento
    {
        public pizza_complemento()
        {
            ComplementCategories = new List<complement_categorie>();
        }

        public string title { get; set; }
        public decimal price { get; set; }
        public int qtd_sabor { get; set; }
        public string ref_ { get; set; }
        public string ref_sabor_tamanho { get; set; }

        public List<complement_categorie> ComplementCategories { get; set; }
    }
}
