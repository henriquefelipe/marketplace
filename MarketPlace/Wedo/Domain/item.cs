using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Domain
{
    public class item
    {
        public string reference { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string externalCode { get; set; }
        public decimal totalPrice { get; set; }
        public string observations { get; set; }
        public List<subItem> subItems { get; set; }
        public List<complementGroup> complementGroups { get; set; }
        public decimal unityFraction { get; set; }
        public decimal originalPrice { get; set; }
    }

    public class complementGroup
    {
        public string title { get; set; }
        public bool fractionalItems { get; set; }
        public int fractions { get; set; }
        public List<groupItem> groupItems { get; set; }
    }

    public class groupItem
    {
        public string reference { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal totalPrice { get; set; }
        public decimal unityFraction { get; set; }
        public string externalCode { get; set; }
        public decimal originalPrice { get; set; }
    }

    public class subItem
    {
        public string title { get; set; }
        public bool fractionalItems { get; set; }
        public int fractions { get; set; }
        public List<item> items { get; set; }
    }
}
