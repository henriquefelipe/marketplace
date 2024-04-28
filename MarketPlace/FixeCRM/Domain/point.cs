using System;
using System.Collections.Generic;
using System.Text;

namespace FixeCRM.Domain
{
    public class point
    {
        public point() 
        {
            details = new List<point_details>();
        }

        public string id_user { get; set; }
        public string id_passbook { get; set; }
        public string uniqueId { get; set; }
        public decimal value { get; set; }
        public string source { get; set; }
        public string location { get; set; }
        public string externalId { get; set; }
        public List<point_details> details { get; set; }
        public bool is_delivery { get; set; }
    }

    public class point_details
    {
        public string sku { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }
}
