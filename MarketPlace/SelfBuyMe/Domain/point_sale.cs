using System;
using System.Collections.Generic;
using System.Text;

namespace SelfBuyMe.Domain
{
    public class point_sale
    {
        public int id { get; set; }
        public string name { get; set; }
        public point_sale_address address { get; set; }
        public point_sale_point_sale_group point_sale_group { get; set; }
    }

    public class point_sale_address
    {
        public int id { get; set; }
        public string postal_code { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }

    public class point_sale_point_sale_group
    {
        public int id{ get; set; }
        public string name { get; set; }
    }
}
