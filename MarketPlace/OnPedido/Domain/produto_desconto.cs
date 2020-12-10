using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPedido.Domain
{
    public class produto_desconto
    {
        public bool status { get; set; }
        public decimal percentual { get; set; }
        public decimal valor { get; set; }
    }
}
