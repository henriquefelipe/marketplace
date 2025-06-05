using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class paymentMethodsResult
    {
        public paymentMethods PaymentMethods {  get; set; }
    }

    public class paymentMethods
    {
        public paymentMethods()
        {
            credit = new List<paymentMethod>();
            order = new List<paymentMethod>();
        }


        public List<paymentMethod> credit { get; set; }
        public List<paymentMethod> order { get; set; }
    }

    public class paymentMethod
    {
        public string id { get; set; }
        public string display_name { get; set; }
        public string operator_name { get; set; }
        public string identifier { get; set; }
        public string status { get; set; }
        public paymentMethodIntegrator Integrator { get; set; }
    }

    public class paymentMethodIntegrator
    {
        public string id { get; set; }
        public string identifier { get; set; }
        public string group { get; set; }
        public string subgroup { get; set; }
        public string broker { get; set; }
        public string method { get; set; }
        public string action { get; set; }
        public string redirection { get; set; }
    }
}
