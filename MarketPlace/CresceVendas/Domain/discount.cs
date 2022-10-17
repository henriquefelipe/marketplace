using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Domain
{
    public class discount
    {
        public discount()
        {
            products = new List<product>();
        }

        public decimal subtotal { get; set; }
        public List<product> products { get; set; }
    }
    
}
