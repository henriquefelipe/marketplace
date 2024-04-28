using System;
using System.Collections.Generic;
using System.Text;

namespace SelfBuyMe.Domain
{
    public class payment
    {
        public payment_form payment_form { get; set; }
        public payment_form_transaction transaction { get; set; }
    }

    public class payment_form
    {
        public int id { get; set; }
        public string name { get; set; }
        public payment_form_financial_intermediary financial_intermediary { get; set; }
        public payment_form_payment_method payment_method { get; set; }
    }

    public class payment_form_financial_intermediary
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class payment_form_payment_method
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class payment_form_transaction
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string payment_id { get; set; }
        public decimal total_price { get; set; }
        public string notes { get; set; }
        public int installments { get; set; }
    }

}
