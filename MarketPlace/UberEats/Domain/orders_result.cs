﻿using System.Collections.Generic;

namespace UberEats.Domain
{
    public class orders_result
    {
        public orders_result()
        {
            orders = new List<order_result>();
        }

        public List<order_result> orders { get; set; }
    }

    public class order_result
    {
        public string id { get; set; }
        public string current_state { get; set; }
        public string placed_at { get; set; }
    }
}
