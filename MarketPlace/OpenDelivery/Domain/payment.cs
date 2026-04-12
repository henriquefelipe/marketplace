using System.Collections.Generic;

namespace OpenDelivery.Domain
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
        public string type { get; set; }
        public string method { get; set; }
        public string brand { get; set; }
        public string methodInfo { get; set; }
        public payment_transaction transaction { get; set; }        
        public decimal changeFor { get; set; }                       
    }

    public class payment_transaction
    {
        public string authorizationCode { get; set; }
        public string acquirerDocument { get; set; }
    }
}
