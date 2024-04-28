using System;
using System.Collections.Generic;
using System.Text;

namespace FixeCRM.Domain
{
    public class consultaRetornaSelo
    {
        public consultaRetornaSelo()
        {
            type = new List<string>();
            discounts = new List<consultaRetornaSelo_discounts>();
            products = new List<consultaRetornaSelo_products>();
        }

        public string email { get; set; }
        public string points { get; set; }
        public List<string> type { get; set; }
        public bool hasPinNumber { get; set; }
        public int? pinNumber { get; set; }
        public bool birthday { get; set; }
        public string redeemType { get; set; }
        public List<consultaRetornaSelo_discounts> discounts { get; set; }
        public List<consultaRetornaSelo_products> products { get; set; }
        public consultaRetornaSelo_user user { get; set; }
    }

    public class consultaRetornaSelo_user
    {
        public string position { get; set; }
        public string nextLevel { get; set; }
        public string name { get; set; }
        public string uniqueId { get; set; }
    }

    public class consultaRetornaSelo_discounts
    {
        public string name { get; set; }
        public decimal value { get; set; }
    }

    public class consultaRetornaSelo_products
    {
        public string name { get; set; }
        public string sku { get; set; }
        public decimal price { get; set; }
    }
}
