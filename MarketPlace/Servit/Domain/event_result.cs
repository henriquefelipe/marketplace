﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class event_result
    {
        public event_result()
        {
            events = new List<evento>();
        }

        public List<evento> events { get; set; }
    }

    public class evento
    {
        public evento()
        {
            payments = new List<payment>();
        }

        public int id { get; set; }
        public string origin { get; set; }
        public string model { get; set; }
        public string description { get; set; }        
        public string status { get; set; }
        public string type { get; set; }

        public data data { get; set; }
        public order order { get; set; }
        public bill bill { get; set; }
        public table table { get; set; }
        public waiter waiter { get; set; }
        public order_product order_product { get; set; }
        public List<payment> payments { get; set; }
        public environment environment { get; set; }
    }
}
