using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accon.Domain
{
    public class store
    {
        public string _id { get; set; }
        public string name { get; set; }
        public address address { get; set; }
        public string deliveryTime { get; set; }
        public string toGoTime { get; set; }
        //details Objeto com informações adicionais de contato com a loja
    }
}
