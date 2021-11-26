using System.Collections.Generic;

namespace Ifood.Domain
{
    public class payment
    {
        public payment()
        {
            methods = new List<payment_methods>();
        }

        public decimal prepaid { get; set; }
        public decimal pending { get; set; }
        public List<payment_methods> methods { get; set; }       
    }

    public class payment_methods
    {
        public decimal value { get; set; }
        public string currency { get; set; }
        public string method { get; set; }
        public string type { get; set; }
        public payment_methods_wallet wallet { get; set; }        
        public bool prepaid { get; set; }                
        public payment_methods_cash cash { get; set; }
        public payment_methods_card card { get; set; }
    }

    public class payment_methods_wallet
    {
        public string name { get; set; }
    }

    public class payment_methods_cash
    {
        public decimal changeFor { get; set; }
    }

    public class payment_methods_card
    {
        public string brand { get; set; }
    }
}
