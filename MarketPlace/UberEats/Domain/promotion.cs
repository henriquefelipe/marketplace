using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain
{
    public class promotion
    {
        public promotion()
        {
            discount_items = new List<discount_item>();
        }

        public string external_promotion_id { get; set; }
        public string promo_type { get; set; }
        public decimal promo_discount_value { get; set; }
        public decimal promo_discount_percentage { get; set; }
        public List<discount_item> discount_items { get; set; }
    }

    public class discount_item
    {
        public string external_id { get; set; }
        public decimal discounted_quantity { get; set; }
    }
}
