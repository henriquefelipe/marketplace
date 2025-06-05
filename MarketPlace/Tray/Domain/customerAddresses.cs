using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class customerAddresses
    {
        public string id {  get; set; }
        public string customer_id { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
        public string type { get; set; }
        public string active { get; set; }
        public string description { get; set; }
        public string recipient { get; set; }
        public string type_delivery { get; set; }
        public string not_list { get; set; }
    }
}
