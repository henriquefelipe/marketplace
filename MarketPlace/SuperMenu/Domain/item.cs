using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu.Domain
{
    public class item
    {
        public item()
        {
            subItems = new List<subItem>();
        }

        public string reference { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public decimal subItemsPrice { get; set; }
        public decimal totalPrice { get; set; }
        public decimal discount { get; set; }
        public string externalCode { get; set; }
        public string observations { get; set; }

        public decimal offerValue { get; set; }
        public decimal totalOfferValue { get; set; }
        public decimal finalPrice { get; set; }
        public decimal totalFinalPrice { get; set; }
        public item_relatedOffer relatedOffer { get; set; }

        public List<subItem> subItems { get; set; }
    }

    public class item_relatedOffer
    {
        public string offerId { get; set; }
        public item_relatedOffer_discountType discountType { get; set; }
    }

    public class item_relatedOffer_discountType
    {
        public int value { get; set; }
        public int type { get; set; }
    }
}
