using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Domain
{
    public class order_item
    {
        public order_item()
        {
            order_additional_items = new List<order_item_addicional>();
            order_mandatory_items = new List<order_item_mandatory>();
        }

        public string id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string category_name { get; set; }
        public string size { get; set; }
        public decimal unit_value { get; set; }
        public string promotional_value { get; set; }
        public decimal quantity { get; set; }
        public decimal? discount_tax { get; set; }
        public string description { get; set; }
        public string observations { get; set; }

        public List<order_item_addicional> order_additional_items { get; set; }
        public List<order_item_mandatory> order_mandatory_items { get; set; }
        //public List<order_item_mandatory> order_item_subitems { get; set; }
    }
}
