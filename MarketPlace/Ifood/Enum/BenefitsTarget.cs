using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Enum
{
    public class BenefitsTarget
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

        /// <summary>
        /// desconto progressivo em itens iguais do pedido, formando um combo.
        /// </summary>
        public const string PROGRESSIVE_DISCOUNT_ITEM = "PROGRESSIVE_DISCOUNT_ITEM";
    }
}
