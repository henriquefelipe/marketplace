using System;
using System.Collections.Generic;
using System.Text;

namespace PixCommerce.Domain
{
    public class item
    {
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public string externalCode { get; set; }
        public decimal totalPrice { get; set; }
        public int index { get; set; }
        public string unit { get; set; }
        public string ean { get; set; }
        public decimal price { get; set; }
        public string observations { get; set; }
        public string imageUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public decimal optionsPrice { get; set; }
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
        public int minQuantity { get; set; }
        public decimal price { get; set; }
    }
}
