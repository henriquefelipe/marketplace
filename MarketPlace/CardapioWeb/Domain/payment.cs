using System;
using System.Collections.Generic;
using System.Text;

namespace CardapioWeb.Domain
{
    public class payment
    {
        public decimal total { get; set; }
        public string status { get; set; }
        public string card_brand { get; set; }
        public decimal? change_for { get; set; }
        public string card_number { get; set; }
        public string observation { get; set; }
        public decimal payment_fee { get; set; }
        public string payment_type { get; set; }
        public string payment_method { get; set; }

    }
}
