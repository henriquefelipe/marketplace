using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Enum
{
    public enum OrderItemType
    {
        item,
        delivery_fee,
        tip,
        promo_cart,
        promo_item,
        promo_cart_item,
        service_fee_subtotal,
        service_fee_total,
        cash_discount
    }
}
