using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDelivery.Enum
{
    public class DiscountsTarget
    {
        /// <summary>
        /// desconto no valor somado dos itens;
        /// </summary>
        public const string CART = "CART";

        /// <summary>
        /// desconto na taxa de entrega;
        /// </summary>
        public const string DELIVERY_FEE = "DELIVERY_FEE";

        /// <summary>
        /// desconto em um item do pedido;
        /// </summary>
        public const string ITEM = "ITEM";
      
    }
}
