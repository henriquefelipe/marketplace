using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Domain
{
    public class order_new_retorno
    {
        public order_new_retorno()
        {
            orders = new List<order_new_retorno_order>();
        }

        public string status { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public List<order_new_retorno_order> orders { get; set; }       
    }

    public class order_new_retorno_order
    {
        public string message { get; set; }
        public int status { get; set; }
        public string id { get; set; }

    }
}
