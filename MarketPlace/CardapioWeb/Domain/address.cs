using System;
using System.Collections.Generic;
using System.Text;

namespace CardapioWeb.Domain
{
    public class address
    {
        public string street {  get; set; }
        public string number { get; set; }
        public string address_block { get; set; }
        public string address_lot { get; set; }
        public string neighborhood { get; set; }
        public string complement { get; set; }
        public string reference { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
