using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Domain
{
    public class item
    {
        public string externalId { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal totalPrice { get; set; } // Utilizado na versão 1
        public decimal unitPrice { get; set; } // Utilizado na versão 1
        public decimal new_totalPrice { get; set; } // Utilizado na versão 1
        public decimal new_unitPrice { get; set; } // Utilizado na versão 1
        public decimal price { get; set; } // Utilizado na versão 2
        public decimal total { get; set; } // Utilizado na versão 2
        public string observation { get; set; } 
        public string priceModel { get; set; }
       
        public List<subitem> subItems { get; set; }
    }

    public class subitem
    {
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal totalPrice { get; set; } // Utilizado na versão 1
        public decimal unitPrice { get; set; } // Utilizado na versão 1 
        public decimal new_totalPrice { get; set; } // Utilizado na versão 1
        public decimal new_unitPrice { get; set; } // Utilizado na versão 1

        public decimal price { get; set; } // Utilizado na versão 2
        public decimal total { get; set; } // Utilizado na versão 2
        public string externalCode { get; set; }
        public string externalId { get; set; }
    }
}
