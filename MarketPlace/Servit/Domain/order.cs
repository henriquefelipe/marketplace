﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class order
    {
        public order()
        {
            order_products = new List<order_product>();
        }

        public int id { get; set; }
        public decimal price { get; set; }
        public int status_id { get; set; }
        public string note { get; set; }
        public string created_at { get; set; }
        public bill bill { get; set; }
        public List<order_product> order_products { get; set; }
    }
}