using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class payment
    {
        public DateTime created {  get; set; }
        public DateTime modified { get; set; }
        public string id { get; set; }
        public string order_id { get; set; }
        public string payment_method_id { get; set; }
        public string method { get; set; }
        public string payment_place { get; set; }
        public decimal value { get; set; }
        public DateTime date { get; set; }
        public string note { get; set; }
        public string unique_number { get; set; }
    }
}
