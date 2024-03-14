using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class item
    {
        public item()
        {
            options = new List<subItem>();
        }

        public int index { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string uniqueId { get; set; }
        public string externalCode { get; set; }
        public string unit { get; set; }
        public string ean { get; set; }
        public decimal quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal price { get; set; }
        public decimal totalPrice { get; set; }
        public decimal optionsPrice { get; set; }                
        public decimal addition { get; set; }

        //public decimal discount { get; set; }
        public string observations { get; set; }
        public string imageUrl { get; set; }

        public List<subItem> options { get; set; }
        public item_scalePrices scalePrices { get; set; }
    }

    public class item_scalePrices
    {
        public item_scalePrices()
        {
            scales = new List<item_scalePrices_scales>();
        }

        public decimal defaultPrice { get; set; }
        public List<item_scalePrices_scales> scales { get; set; }
    }

    public class item_scalePrices_scales
    {
        public decimal minQuantity { get; set; }
        public decimal price { get; set; }
    }
}
